namespace TodoApp.Application.Todos.Queries;

public class GetPendingTodosQueryHandler : IRequestHandler<GetPendingTodosQuery, List<TodoItemDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICurrentUserService _currentUserService;

    public GetPendingTodosQueryHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUserService)
    {
        _unitOfWork = unitOfWork;
        _currentUserService = currentUserService;
    }
    
    public async Task<List<TodoItemDto>> Handle(GetPendingTodosQuery request, CancellationToken cancellationToken)
    {
        var todos = await _unitOfWork.Todos.GetPendingByUserIdAsync(_currentUserService.UserId);
        
        return todos.Select(t => new TodoItemDto
        {
            Id = t.Id,
            Title = t.Title,
            Description = t.Description,
            IsCompleted = t.IsCompleted,
            Priority = t.Priority,
            DueDate = t.DueDate,
            CreatedAt = t.CreatedAt,
            CompletedAt = t.CompletedAt,
            CategoryId = t.CategoryId,
            Category = new CategoryDto
            {
                Id = t.Category.Id,
                Name = t.Category.Name,
                Color = t.Category.Color,
                TodoCount = t.Category.TodoItems?.Count ?? 0
            }
        }).ToList();
    }
}