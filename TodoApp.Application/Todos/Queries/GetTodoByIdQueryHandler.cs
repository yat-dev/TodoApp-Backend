namespace TodoApp.Application.Todos.Queries;

public class GetTodoByIdQueryHandler : IRequestHandler<GetTodoByIdQuery, TodoItemDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICurrentUserService _currentUserService;

    public GetTodoByIdQueryHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUserService)
    {
        _unitOfWork = unitOfWork;
        _currentUserService = currentUserService;
    }
    
    public async Task<TodoItemDto> Handle(GetTodoByIdQuery request, CancellationToken cancellationToken)
    {
        var todo = await _unitOfWork.Todos.GetByIdAsync(request.Id);
        
        if (todo == null || todo.UserId != _currentUserService.UserId)
            throw new NotFoundException(nameof(TodoItem), request.Id);

        return new TodoItemDto()
        {
            Id = todo.Id,
            Title = todo.Title,
            Description = todo.Description,
            IsCompleted = todo.IsCompleted,
            Priority = todo.Priority,
            DueDate = todo.DueDate,
            CreatedAt = todo.CreatedAt,
            CompletedAt = todo.CompletedAt,
            CategoryId = todo.CategoryId,
            Category = new CategoryDto()
            {
                Id = todo.Category.Id,
                Name = todo.Category.Name,
                Color = todo.Category.Color,
                TodoCount = todo.Category.TodoItems.Count
            }
        };
    }
}