namespace TodoApp.Application.Todos.Queries;

public class GetTodoByIdQuery : IRequest<TodoItemDto>
{
    public int Id { get; set; }
}