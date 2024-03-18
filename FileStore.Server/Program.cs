using FileStore.Server.Data;
using FileStore.Server.Configuration;

var builder = WebApplication.CreateBuilder(args);

RegisterServices(builder.Services);

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();
    
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
    
app.UseExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();

void RegisterServices(IServiceCollection services)
{
    services.AddDatabase(configuration: builder!.Configuration);
    
    services.AddSwaggerConfiguration();
    
    services.AddJwtAuthentication(configuration: builder!.Configuration);
    
    services.AddControllers();
    
    services.AddApplicationServices();
    
    services.AddValidators();
    
    services.AddEndpointsApiExplorer();
    
    services.AddProblemDetails();

    services.AddAuthorization();
}

// For WebApplicationFactory in integration tests.
public partial class Program { }


