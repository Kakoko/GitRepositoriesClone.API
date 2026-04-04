using GitRepositoriesClone.API.Models;
using GitRepositoriesClone.API.Repositories;
using MediatR;

namespace GitRepositoriesClone.API.Features.Repositories.Queries
{
    public class GetAllRepositoriesHandler : IRequestHandler<GetAllRepositoriesQuery, IEnumerable<Repository>>
    {
        private readonly IRepositoryRepository _repository;

        public GetAllRepositoriesHandler(IRepositoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Repository>> Handle(GetAllRepositoriesQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync();
        }

        //public async Task<IEnumerable<Repository>> Handle()
        //{
        //    return await _repository.GetAllAsync();
        //}
    }
}
