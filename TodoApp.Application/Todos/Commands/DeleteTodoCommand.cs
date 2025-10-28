using MediatR;

namespace TodoApp.Application.Todos.Commands;

public class DeleteTodoCommand : IRequest
{
    public int Id { get; set; }
}