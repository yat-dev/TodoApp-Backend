using TodoApp.Domain.Entities;

namespace TodoApp.Domain.Repositories;

public interface ITodoRepository
{
    Task<TodoItem> GetByIdAsync(int id);
    Task<IEnumerable<TodoItem>> GetAllByUserIdAsync(int userId);
    Task<IEnumerable<TodoItem>> GetCompletedByUserIdAsync(int userId);
    Task<IEnumerable<TodoItem>> GetPendingByUserIdAsync(int userId);
    Task<IEnumerable<TodoItem>> GetByCategoryIdAsync(int categoryId);
    Task<TodoItem> AddAsync(TodoItem todo);
    Task UpdateAsync(TodoItem todo);
    Task DeleteAsync(TodoItem todo);
}