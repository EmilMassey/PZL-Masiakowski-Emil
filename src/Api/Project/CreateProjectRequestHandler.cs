using TaskFlow.Application;

namespace TaskFlow.Api.Project;

public class CreateProjectRequestHandler(IClock clock)
{
    public void Handle(CreateProjectRequest request)
    {
        new Domain.Project.Project(request.Id, request.Name, request.Description, clock.Now());
    }
}