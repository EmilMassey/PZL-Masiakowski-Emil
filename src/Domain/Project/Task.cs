namespace TaskFlow.Domain.Project;

public class Task(Guid id, Project project, string title, string? description, DateTime createdAt)
{
    public Guid Id { get; } = id;
    public string Title { get; private set; } = title;
    public string? Description { get; set; } = description;
    public DateTime CreatedAt { get; } = createdAt;
    private TaskState State { get; set; } = TaskState.New;
    private ICollection<Comment> Comments { get; } = new List<Comment>();

    public void ChangeTitle(string newTitle)
    {
        if (Title == newTitle)
        {
            return;
        }
        
        project.ValidateNotArchived();
        project.ValidateTaskTitleDoesNotExist(newTitle);
        
        Title = newTitle;
    }

    public void TransitionState(TaskState newState)
    {
        project.ValidateNotArchived();
        
        ValidateTransitionAllowed(newState);
        
        State = newState;
    }

    public void AddComment(Guid commentId, string content, DateTime createdAt)
    {
        project.ValidateNotArchived();

        var comment = new Comment(commentId, this, content, createdAt);
        
        Comments.Add(comment);
    }

    public bool IsTransitionAllowed(TaskState newState)
    {
        return State switch
        {
            TaskState.New => newState is TaskState.ToDo or TaskState.WillNotDo,
            TaskState.ToDo => newState is TaskState.InProgress or TaskState.WillNotDo,
            TaskState.InProgress => newState is TaskState.WillNotDo or TaskState.InReview or TaskState.Done,
            TaskState.InReview => newState is TaskState.Done or TaskState.InProgress,
            _ => false
        };
    }

    private void ValidateTransitionAllowed(TaskState newState)
    {
        if (!IsTransitionAllowed(newState))
        {
            throw new Exception($"Transition from {State} to {newState} is not allowed");
        }
    }
}