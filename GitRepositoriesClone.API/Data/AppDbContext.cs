using GitRepositoriesClone.API.Models;
using Microsoft.EntityFrameworkCore;

namespace GitRepositoriesClone.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Repository> Repositories => Set<Repository>();
    }
}
