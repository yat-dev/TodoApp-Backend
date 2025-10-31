namespace TodoApp.Application.Todos.Commands;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICurrentUserService _currentUserService;

    public CreateCategoryCommandHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUserService)
    {
        _unitOfWork = unitOfWork;
        _currentUserService = currentUserService;
    }
    
    public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = new Category(
            request.Name, 
            request.Color, 
            _currentUserService.UserId
        );

        await _unitOfWork.Categories.AddAsync(category);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return category.Id;
    }
}