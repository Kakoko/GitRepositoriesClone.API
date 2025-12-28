using GitRepositoriesClone.API.Data;
using GitRepositoriesClone.API.Models;
using Microsoft.EntityFrameworkCore;

namespace GitRepositoriesClone.API.Repositories
{
    public class RepositoryRepository : GenericRepository<Repository> , IRepositoryRepository
    {
        //private readonly AppDbContext _context;

        public RepositoryRepository(AppDbContext context) : base(context)
        {
            
        }
        //public async Task AddAsync(Repository repository)
        //{
        //    _context.Repositories.Add(repository);
        //    await _context.SaveChangesAsync();
        //}

        //public async Task DeleteAsync(Repository repository)
        //{
        //    _context.Repositories.Remove(repository);
        //    await _context.SaveChangesAsync();
        //}

        //public async Task<IEnumerable<Repository>> GetAllAsync()
        //{
        //    return await _context.Repositories.ToListAsync();
        //}

        //public async Task<Repository?> GetByIdAsync(Guid id)
        //{
        //    return await _context.Repositories.FindAsync(id);
        //}

        //public async Task UpdateAsync(Repository repository)
        //{
        //    await _context.SaveChangesAsync();
        //}
    }
}
