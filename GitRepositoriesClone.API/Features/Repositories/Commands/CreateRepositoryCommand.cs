using GitRepositoriesClone.API.Models;
using MediatR;

namespace GitRepositoriesClone.API.Features.Repositories.Commands
{
    public class CreateRepositoryCommand : IRequest<Repository>
    {
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
