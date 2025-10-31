using Microsoft.EntityFrameworkCore;
using TodoApp.Domain.Entities;
using TodoApp.Domain.Repositories;

namespace TodoApp.Infrastructure.Persistence.Repositories;

public class TodoRepository : ITodoRepository
    {
        private readonly ApplicationDbContext _context;

        public TodoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TodoItem> GetByIdAsync(int id)
        {
            return (await _context.TodoItems
                .Include(t => t.Category)
                .FirstOrDefaultAsync(t => t.Id == id))!;
        }

        public async Task<List<TodoItem>> GetAllByUserIdAsync(int userId)
        {
            return await _context.TodoItems
                .Where(t => t.UserId == userId)
                .Include(t => t.Category)
                .OrderByDescending(t => t.CreatedAt)
                .ToListAsync();
        }

        public async Task<List<TodoItem>> GetCompletedByUserIdAsync(int userId)
        {
            return await _context.TodoItems
                .Where(t => t.UserId == userId && t.IsCompleted)
                .Include(t => t.Category)
                .OrderByDescending(t => t.CompletedAt)
                .ToListAsync();
        }

        public async Task<List<TodoItem>> GetPendingByUserIdAsync(int userId)
        {
            return await _context.TodoItems
                .Where(t => t.UserId == userId && !t.IsCompleted)
                .Include(t => t.Category)
                .OrderByDescending(t => t.CreatedAt)
                .ToListAsync();
        }

        public async Task<IEnumerable<TodoItem>> GetByCategoryIdAsync(int categoryId)
        {
            return await _context.TodoItems
                .Where(t => t.CategoryId == categoryId)
                .OrderByDescending(t => t.CreatedAt)
                .ToListAsync();
        }

        public async Task<TodoItem> AddAsync(TodoItem todo)
        {
            await _context.TodoItems.AddAsync(todo);
            return todo;
        }

        public Task UpdateAsync(TodoItem todo)
        {
            _context.TodoItems.Update(todo);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(TodoItem todo)
        {
            _context.TodoItems.Remove(todo);
            return Task.CompletedTask;
        }
    }