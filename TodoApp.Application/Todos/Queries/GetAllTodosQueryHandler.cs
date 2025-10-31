namespace TodoApp.Application.Todos.Queries;

public class GetAllTodosQueryHandler : IRequestHandler<GetAllTodosQuery, List<TodoItemDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICurrentUserService _currentUserService;

    public GetAllTodosQueryHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUserService)
    {
        _unitOfWork = unitOfWork;
        _currentUserService = currentUserService;
    }
    
    public async Task<List<TodoItemDto>> Handle(GetAllTodosQuery request, CancellationToken cancellationToken)
    {
        var todos = await _unitOfWork.Todos.GetAllByUserIdAsync(_currentUserService.UserId);
            
        // ✅ Mapping manuel
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
            Category = t.Category != null ? new CategoryDto
            {
                Id = t.Category.Id,
                Name = t.Category.Name,
                Color = t.Category.Color,
                TodoCount = t.Category.TodoItems?.Count ?? 0
            } : null
        }).ToList();
    }
}