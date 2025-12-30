using GitRepositoriesClone.API.Data;
using GitRepositoriesClone.API.Models;
using Microsoft.EntityFrameworkCore;

namespace GitRepositoriesClone.API.Repositories
{
    public class RepositoryRepository : GenericRepository<Repository>, IRepositoryRepository
    {
    

        public RepositoryRepository(AppDbContext context) : base(context)
        {
           
        }
        
    }
}
