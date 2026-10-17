namespace TaskFlow.Domain.Project;

public class Comment(Guid id, Task task, string content, DateTime createdAt)
{
    public Guid Id { get; } = id;
    public string Content { get; } = content;
    public DateTime CreatedAt { get; } = createdAt;
}