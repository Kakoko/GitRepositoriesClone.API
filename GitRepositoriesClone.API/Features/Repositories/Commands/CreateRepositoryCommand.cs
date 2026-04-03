namespace GitRepositoriesClone.API.Features.Repositories.Commands
{
    public class CreateRepositoryCommand
    {
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
