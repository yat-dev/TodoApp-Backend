namespace TodoApp.Application.Todos.Queries;

public class GetTodoByIdQueryHandler : IRequestHandler<GetTodoByIdQuery, TodoItemDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICurrentUserService _currentUserService;
    private readonly IMapper _mapper;

    public GetTodoByIdQueryHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUserService, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _currentUserService = currentUserService;   
        _mapper = mapper;
    }
    
    public async Task<TodoItemDto> Handle(GetTodoByIdQuery request, CancellationToken cancellationToken)
    {
        var todo = await _unitOfWork.Todos.GetByIdAsync(request.Id);
        
        if (todo == null || todo.UserId != _currentUserService.UserId)
            throw new NotFoundException(nameof(TodoItem), request.Id);
        
        return _mapper.Map<TodoItemDto>(todo);
    }
}