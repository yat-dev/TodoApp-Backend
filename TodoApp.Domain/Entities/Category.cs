using TodoApp.Domain.Common;

namespace TodoApp.Domain.Entities;

public class Category : BaseEntity
{
    public string Name { get; private set; }
    public string Color { get; private set; }
    public int UserId { get; private set; }
    public User User { get; private set; }
        
    private readonly List<TodoItem> _todoItems = new();
    public IReadOnlyCollection<TodoItem> TodoItems => _todoItems.AsReadOnly();

    private Category() { } // Pour EF Core

    public Category(string name, string color, int userId)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be empty", nameof(name));
            
        Name = name;
        Color = color ?? "#000000";
        UserId = userId;
    }

    public void UpdateDetails(string name, string color)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be empty", nameof(name));
            
        Name = name;
        Color = color ?? Color;
    }
}