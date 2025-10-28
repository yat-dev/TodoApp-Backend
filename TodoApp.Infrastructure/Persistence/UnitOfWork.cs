using TodoApp.Domain.Repositories;
using TodoApp.Infrastructure.Persistence.Repositories;

namespace TodoApp.Infrastructure.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
        Users = new UserRepository(context);
        Todos = new TodoRepository(context);
        Categories = new CategoryRepository(context);
    }

    public IUserRepository Users { get; }
    public ITodoRepository Todos { get; }
    public ICategoryRepository Categories { get; }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}