using System.Collections;

namespace TaskFlow.Domain.Project;

public class Project(Guid id, string name, string? description, DateTime createdAt)
{
    public Guid Id { get; } = id;
    public string Name { get; set; } = name;
    public string? Description { get; set; } = description;
    public DateTime CreatedAt { get; } = createdAt;
    public ProjectState State { get; private set; } = ProjectState.Active;
    public DateTime? ArchivedAt { get; private set; }
    private ICollection<Task> Tasks { get; } = new List<Task>();

    public void CreateTask(Guid taskId, string title, string? description, DateTime createdAt)
    {
        ValidateNotArchived();
        ValidateTaskTitleDoesNotExist(title);
        
        var newTask = new Task(taskId, this, title, description, createdAt);
        
        Tasks.Add(newTask);
    }

    public Task? FindTask(Guid taskId)
    {
        return Tasks.FirstOrDefault(comment => comment.Id == taskId);
    }

    public void Archive(DateTime archivedAt)
    {
        if (State == ProjectState.Archived)
        {
            throw new Exception("Project is already archived");
        }
        
        State = ProjectState.Archived;
        ArchivedAt = archivedAt;
    }

    public void ValidateNotArchived()
    {
        if (State == ProjectState.Archived)
        {
            throw new Exception("Project is archived and cannot be modified");
        }
    }

    public void ValidateTaskTitleDoesNotExist(string title)
    {
        if (Tasks.Any(currentTask => currentTask.Title == title))
        {
            throw new Exception($"Task {title} is already created");
        }
    }
}