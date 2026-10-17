namespace TaskFlow.Api.Project;

public class CreateProjectRequest(Guid id, string name, string? description)
{
    public Guid Id { get; } = id;
    public string Name { get; } = name;
    public string? Description { get; } = description;
}