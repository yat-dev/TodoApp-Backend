using MediatR;

namespace TodoApp.Application.Todos.Commands;

public class CreateCategoryCommand : IRequest<int>
{
    public string Name { get; set; }
    public string Color { get; set; }
}