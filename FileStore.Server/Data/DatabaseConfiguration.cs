using Microsoft.EntityFrameworkCore;
using Minio;

namespace FileStore.Server.Data;

public static class DatabaseConfiguration
{
    public static void AddDatabases(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(connectionString: 
                configuration.GetConnectionString("DefaultConnection")));

        services.AddMinio(configureClient: client =>
        {
            client.WithEndpoint(configuration["Minio:Endpoint"]);
            client.WithCredentials(
                configuration["Minio:AccessKey"], 
                configuration["Minio:SecretKey"]);
            client.WithSSL();
        });
    }
}