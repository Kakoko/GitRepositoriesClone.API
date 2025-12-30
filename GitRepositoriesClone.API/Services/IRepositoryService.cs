using GitRepositoriesClone.API.Data.Dtos;
using GitRepositoriesClone.API.Models;

namespace GitRepositoriesClone.API.Services
{
    public interface IRepositoryService
    {
        Task<IEnumerable<Repository>> GetAllAsync();
        Task<Repository?> GetByIdAsync(Guid id);
        Task<Repository> CreateAsync(CreateRepositoryRequest request);
        Task<Repository?> UpdateAsync(Guid id, UpdateRepositoryRequest request);
        Task<bool> DeleteAsync(Guid id);
    }
}
