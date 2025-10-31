namespace TodoApp.Application.Todos.Queries;

public class GetAllTodosQueryHandler : IRequestHandler<GetAllTodosQuery, List<TodoItemDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICurrentUserService _currentUserService;
    private readonly IMapper _mapper;

    public GetAllTodosQueryHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUserService, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _currentUserService = currentUserService;
        _mapper = mapper;
    }
    
    public async Task<List<TodoItemDto>> Handle(GetAllTodosQuery request, CancellationToken cancellationToken)
    {
        var todos = await _unitOfWork.Todos.GetAllByUserIdAsync(_currentUserService.UserId);

        return _mapper.Map<List<TodoItemDto>>(todos);
    }
}