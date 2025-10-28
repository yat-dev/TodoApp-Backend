using TodoApp.Domain.Enums;

namespace TodoApp.Application.Dtos;

public class TodoItemDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }
    public Priority Priority { get; set; }
    public DateTime? DueDate { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? CompletedAt { get; set; }
    public int? CategoryId { get; set; }
    public CategoryDto Category { get; set; }
}