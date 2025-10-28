using TodoApp.Domain.Entities;

namespace TodoApp.Domain.Repositories;

public interface ICategoryRepository
{
    Task<Category> GetByIdAsync(int id);
    Task<IEnumerable<Category>> GetAllByUserIdAsync(int userId);
    Task<Category> AddAsync(Category category);
    Task UpdateAsync(Category category);
    Task DeleteAsync(Category category);
}