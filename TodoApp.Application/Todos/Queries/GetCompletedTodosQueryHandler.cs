namespace TodoApp.Application.Todos.Queries;

public class GetCompletedTodosQueryHandler : IRequestHandler<GetCompletedTodosQuery, List<TodoItemDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICurrentUserService _currentUserService;
    private readonly IMapper _mapper;

    public GetCompletedTodosQueryHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUserService, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _currentUserService = currentUserService;
        _mapper = mapper;
    }
    
    public async Task<List<TodoItemDto>> Handle(GetCompletedTodosQuery request, CancellationToken cancellationToken)
    {
        var todos = _unitOfWork.Todos.GetCompletedByUserIdAsync(_currentUserService.UserId);

        return _mapper.Map<List<TodoItemDto>>(todos);
    }
}