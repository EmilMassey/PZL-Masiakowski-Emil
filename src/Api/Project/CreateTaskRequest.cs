namespace TaskFlow.Api.Project;

public class CreateTaskRequest(Guid id, Guid projectId, string title, string? description)
{
    public Guid Id { get; } = id;
    public Guid ProjectId { get; } = projectId;
    public string Title { get; } = title;
    public string? Description { get; } = description;
}