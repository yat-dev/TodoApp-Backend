namespace TodoApp.Application.Todos.Queries;

public class GetPendingTodosQueryHandler : IRequestHandler<GetPendingTodosQuery, List<TodoItemDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICurrentUserService _currentUserService;
    private readonly IMapper _mapper;

    public GetPendingTodosQueryHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUserService, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _currentUserService = currentUserService;
        _mapper = mapper;
    }
    
    public async Task<List<TodoItemDto>> Handle(GetPendingTodosQuery request, CancellationToken cancellationToken)
    {
        var todos = _unitOfWork.Todos.GetPendingByUserIdAsync(_currentUserService.UserId);
        return _mapper.Map<List<TodoItemDto>>(todos);
    }
}