using FileStore.Server.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace FileStore.Server.Data
{
    public class ApplicationDbContext : DbContext 
    {
        public DbSet<ApplicationUser> Users => Set<ApplicationUser>();

        public ApplicationDbContext(DbContextOptions options) : base(options) 
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
