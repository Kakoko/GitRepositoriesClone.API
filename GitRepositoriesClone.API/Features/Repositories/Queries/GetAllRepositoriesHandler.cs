using GitRepositoriesClone.API.Models;
using GitRepositoriesClone.API.Repositories;

namespace GitRepositoriesClone.API.Features.Repositories.Queries
{
    public class GetAllRepositoriesHandler
    {
        private readonly IRepositoryRepository _repository;

        public GetAllRepositoriesHandler(IRepositoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Repository>> Handle()
        {
            return await _repository.GetAllAsync();
        }
    }
}
