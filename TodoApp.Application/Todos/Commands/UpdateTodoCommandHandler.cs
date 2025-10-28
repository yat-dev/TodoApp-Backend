using MediatR;
using TodoApp.Application.Common.Exceptions;
using TodoApp.Application.Common.Interfaces;
using TodoApp.Domain.Entities;
using TodoApp.Domain.Repositories;

namespace TodoApp.Application.Todos.Commands;

public class UpdateTodoCommandHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUserService)
    : IRequest<UpdateTodoCommand>
{
    public async Task Handle(UpdateTodoCommand request, CancellationToken cancellationToken)
    {
        var todo = await unitOfWork.Todos.GetByIdAsync(request.Id);
        
        if (todo == null || todo.UserId != currentUserService.UserId)
        {
            throw new NotFoundException(nameof(TodoItem), request.Id);
        }
        
        todo.UpdateDetails(request.Title, request.Description, request.Priority, request.DueDate);
        todo.AssignToCategory(request.CategoryId);
        
        if (request.IsCompleted && todo.IsCompleted == false)
            todo.MarkAsCompleted();
        
        else if(request.IsCompleted == false && todo.IsCompleted)
            todo.MarkAsIncomplete();

        await unitOfWork.Todos.UpdateAsync(todo);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}