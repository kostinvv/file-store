using FileStore.Server.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace FileStore.Server.Data
{
    public class ApplicationDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<ApplicationUser> Users => Set<ApplicationUser>();
        public DbSet<StorageObject> StorageObjects => Set<StorageObject>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
