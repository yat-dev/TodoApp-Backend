using MediatR;
using TodoApp.Domain.Entities;

namespace TodoApp.Application.Categories.Queries;

public class GetAllCategoriesQuery :IRequest<List<CategoryDto>>
{
}