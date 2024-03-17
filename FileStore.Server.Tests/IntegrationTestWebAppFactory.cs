namespace FileStore.Server.Tests;

public class IntegrationTestWebAppFactory : WebApplicationFactory<Program>, IAsyncLifetime
{
    private readonly PostgreSqlContainer _postgresContainer = new PostgreSqlBuilder()
            .WithImage("postgres:16.2")
            .WithDatabase("test-file-store")
            .WithUsername("postgres")
            .WithPassword("postgres")
            .Build();
    
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(collection =>
        {
            var descriptor = collection.SingleOrDefault(serviceDescriptor =>
                serviceDescriptor.ServiceType == typeof(DbContextOptions<ApplicationDbContext>));

            if (descriptor is not null)
            {
                collection.Remove(descriptor);
            }

            collection.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(_postgresContainer.GetConnectionString());
            });
            
            var serviceProvider = collection.BuildServiceProvider();
            using var scope = serviceProvider.CreateScope();
            var scopedServices = scope.ServiceProvider;
            var context = scopedServices.GetRequiredService<ApplicationDbContext>();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        });
    }

    public Task InitializeAsync() => _postgresContainer.StartAsync();

    public new Task DisposeAsync() => _postgresContainer.StopAsync();
}