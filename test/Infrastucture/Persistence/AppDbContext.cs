using CQRStest.Domain;
using Microsoft.EntityFrameworkCore;

namespace CQRStest.Infrastucture.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
            
        }

        

        public DbSet<Module> Modules => Set<Module>();
        public DbSet<Permission> Permissions => Set<Permission>();
        public DbSet<User> Users => Set<User>();

    }
}
