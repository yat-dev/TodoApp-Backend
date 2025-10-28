using MediatR;

namespace TodoApp.Application.Todos.Commands;

public class DeleteCategoryCommand : IRequest
{
    public int Id { get; set; }
}