namespace TaskFlow.Api.Project;

public class AddCommentRequest(Guid id, Guid projectId, Guid taskId, string content)
{
    public Guid Id { get; } = id;
    public Guid ProjectId { get; } = projectId;
    public Guid TaskId { get; } = taskId;
    public string Content { get; } = content;
}