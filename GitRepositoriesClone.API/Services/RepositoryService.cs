using GitRepositoriesClone.API.Data.Dtos;
using GitRepositoriesClone.API.Models;
using GitRepositoriesClone.API.Repositories;
using GitRepositoriesClone.API.Validators;

namespace GitRepositoriesClone.API.Services
{
    public class RepositoryService : IRepositoryService
    {
        private readonly IRepositoryRepository _repository;

        public RepositoryService(IRepositoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Repository>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Repository?> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Repository> CreateAsync(CreateRepositoryRequest request)
        {

            RepositoryValidator.Validate(request.Name, request.Description);

            var repository = new Repository
            {
                Name = request.Name,
                Description = request.Description
            };

            await _repository.AddAsync(repository);
            return repository;
        }

        public async Task<Repository?> UpdateAsync(Guid id, UpdateRepositoryRequest request)
        {
            var repository = await _repository.GetByIdAsync(id);

            if (repository == null)
                return null;


            RepositoryValidator.Validate(request.Name, request.Description);


            repository.Name = request.Name;
            repository.Description = request.Description;

            await _repository.UpdateAsync(repository);
            return repository;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var repository = await _repository.GetByIdAsync(id);

            if (repository == null)
                return false;

            await _repository.DeleteAsync(repository);
            return true;
        }

    }

}
