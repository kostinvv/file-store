using FileStore.Server.Data.Repositories;
using FileStore.Server.Interfaces;
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

        services.AddMinio(configureClient =>
        {
            configureClient.WithEndpoint(configuration["Minio:Endpoint"]);
            configureClient.WithCredentials(
                    configuration["Minio:AccessKey"],
                    configuration["Minio:SecretKey"])
                .WithSSL(false);
        });    
    }
    
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IStorageRepository, MinioRepository>();
    }
}