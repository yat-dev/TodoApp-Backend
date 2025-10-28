using AutoMapper;
using TodoApp.Application.Common.Interfaces;
using TodoApp.Domain.Repositories;

namespace TodoApp.Application.Categories.Queries;

public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, IEnumerable<Category>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICurrentUserService _currentUserService;
    private readonly IMapper _mapper;

    public GetAllCategoriesQueryHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUserService, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _currentUserService = currentUserService;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<Category>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categories = _unitOfWork.Categories.GetAllByUserIdAsync(_currentUserService.UserId);
        
        return _mapper.Map<List<Category>>(categories);
    }
}