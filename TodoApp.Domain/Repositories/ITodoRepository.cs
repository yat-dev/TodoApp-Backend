using TodoApp.Domain.Entities;

namespace TodoApp.Domain.Repositories;

public interface ITodoRepository
{
    Task<TodoItem> GetByIdAsync(int id);
    Task<List<TodoItem>> GetAllByUserIdAsync(int userId);
    Task<List<TodoItem>> GetCompletedByUserIdAsync(int userId);
    Task<List<TodoItem>> GetPendingByUserIdAsync(int userId);
    Task<IEnumerable<TodoItem>> GetByCategoryIdAsync(int categoryId);
    Task<TodoItem> AddAsync(TodoItem todo);
    Task UpdateAsync(TodoItem todo);
    Task DeleteAsync(TodoItem todo);
}