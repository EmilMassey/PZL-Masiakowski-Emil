namespace TaskFlow.Domain.Project;

public interface IProjectRepository
{
    public Project? Find(Guid id);
}