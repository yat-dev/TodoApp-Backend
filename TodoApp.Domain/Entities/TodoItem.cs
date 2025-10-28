using TodoApp.Domain.Common;
using TodoApp.Domain.Enums;

namespace TodoApp.Domain.Entities;

public class TodoItem : BaseEntity
{
    public string Title { get; private set; } = null!;
    public string Description { get; private set; } = null!;
    public bool IsCompleted { get; private set; }
    public Priority Priority { get; private set; }
    public DateTime? DueDate { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? CompletedAt { get; private set; }
    
    public int UserId { get; private set; }
    public User User { get; private set; } = null!;

    public int? CategoryId { get; private set; }
    public Category Category { get; private set; } = null!;

    public TodoItem()
    {
    }

    public TodoItem(string title, string description, int userId, Priority priority = Priority.Medium)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Title cannot be empty", nameof(title));
            
        Title = title;
        Description = description ?? string.Empty;
        UserId = userId;
        Priority = priority;
        IsCompleted = false;
        CreatedAt = DateTime.UtcNow;
    }
    
    public void UpdateDetails(string title, string description, Priority priority, DateTime? dueDate)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Title cannot be empty", nameof(title));
            
        Title = title;
        Description = description ?? string.Empty;
        Priority = priority;
        DueDate = dueDate;
    }

    public void MarkAsCompleted()
    {
        if (!IsCompleted)
        {
            IsCompleted = true;
            CompletedAt = DateTime.UtcNow;
        }
    }

    public void MarkAsIncomplete()
    {
        if (IsCompleted)
        {
            IsCompleted = false;
            CompletedAt = null;
        }
    }
    
    public void AssignToCategory(int? categoryId)
    {
        CategoryId = categoryId;
    }

    public bool IsOverdue()
    {
        return !IsCompleted && DueDate.HasValue && DueDate.Value < DateTime.UtcNow;
    }
}