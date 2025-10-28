using MediatR;
using TodoApp.Application.Common.Interfaces;
using TodoApp.Domain.Entities;
using TodoApp.Domain.Repositories;

namespace TodoApp.Application.Todos.Commands;

public class CreateTodoCommandHandler : IRequestHandler<CreateTodoCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICurrentUserService _currentUserService;

    public CreateTodoCommandHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUserService)
    {
        _unitOfWork = unitOfWork;
        _currentUserService = currentUserService;
    }
    
    
    public async Task<int> Handle(CreateTodoCommand request, CancellationToken cancellationToken)
    {
        var todo = new TodoItem(request.Title, request.Description, _currentUserService.UserId, request.Priority);
        
        todo.AssignToCategory(request.CategoryId);
        
        if (request.DueDate.HasValue)
            todo.UpdateDetails(request.Title, request.Description, request.Priority, request.DueDate);

        await _unitOfWork.Todos.AddAsync(todo);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return todo.Id;
    }
}