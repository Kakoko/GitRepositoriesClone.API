using GitRepositoriesClone.API.Models;
using MediatR;

namespace GitRepositoriesClone.API.Features.Repositories.Queries
{
    public class GetAllRepositoriesQuery : IRequest<IEnumerable<Repository>>
    {
    }
}
