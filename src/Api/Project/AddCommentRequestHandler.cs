using TaskFlow.Application;
using TaskFlow.Domain.Project;

namespace TaskFlow.Api.Project;

public class AddCommentRequestHandler(IProjectRepository projectRepository, IClock clock)
{
    public void Handle(AddCommentRequest request)
    {
        var project = projectRepository.Find(request.ProjectId);

        if (project == null)
        {
            throw new Exception("Project not found");
        }

        var task = project.FindTask(request.TaskId);

        if (task == null)
        {
            throw new Exception("Task not found");
        }
        
        task.AddComment(request.Id, request.Content, clock.Now());
    }
}