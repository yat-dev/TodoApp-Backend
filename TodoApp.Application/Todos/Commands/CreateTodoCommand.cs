using MediatR;
using TodoApp.Domain.Enums;

namespace TodoApp.Application.Todos.Commands;

public class CreateTodoCommand : IRequest<int>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public Priority Priority { get; set; }
    public DateTime? DueDate { get; set; }
    public int CategoryId { get; set; }
}