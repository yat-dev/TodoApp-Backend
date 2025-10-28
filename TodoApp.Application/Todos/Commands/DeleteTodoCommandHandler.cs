using MediatR;
using TodoApp.Application.Common.Exceptions;
using TodoApp.Application.Common.Interfaces;
using TodoApp.Domain.Entities;
using TodoApp.Domain.Repositories;

namespace TodoApp.Application.Todos.Commands;

public class DeleteTodoCommandHandler : IRequest<DeleteTodoCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICurrentUserService _currentUserService;

    public DeleteTodoCommandHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUserService)
    {
        _unitOfWork = unitOfWork;
        _currentUserService = currentUserService;
    }

    public async Task Handle(DeleteTodoCommand request, CancellationToken cancellationToken)
    {
        var todo = await _unitOfWork.Todos.GetByIdAsync(request.Id);
        
        if (todo == null || todo.UserId != _currentUserService.UserId)
            throw new NotFoundException(nameof(TodoItem), request.Id);

        await _unitOfWork.Todos.DeleteAsync(todo);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}