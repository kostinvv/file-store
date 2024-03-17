namespace FileStore.Server.Tests;

public abstract class BaseIntegrationTest
    : IClassFixture<IntegrationTestWebAppFactory>
{
    protected readonly HttpClient HttpClient;

    protected readonly ApplicationDbContext DbContext;

    protected BaseIntegrationTest(IntegrationTestWebAppFactory factory)
    {
        var scope = factory.Services.CreateScope();
        
        HttpClient = factory.CreateClient();
        DbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    }
}