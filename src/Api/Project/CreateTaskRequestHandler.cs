using TaskFlow.Application;
using TaskFlow.Domain.Project;

namespace TaskFlow.Api.Project;

public class CreateTaskRequestHandler(IProjectRepository projectRepository, IClock clock)
{
    public void Handle(CreateTaskRequest request)
    {
        var project = projectRepository.Find(request.ProjectId);

        if (project == null)
        {
            throw new Exception("Project not found");
        }
        
        project.CreateTask(request.Id, request.Title, request.Description,  clock.Now());
    }
}