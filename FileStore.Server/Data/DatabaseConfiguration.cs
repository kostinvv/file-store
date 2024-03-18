using Microsoft.EntityFrameworkCore;

namespace FileStore.Server.Data;

public static class DatabaseConfiguration
{
    public static void AddDatabase(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(connectionString: 
                configuration.GetConnectionString("DefaultConnection")));
    }
}