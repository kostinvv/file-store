using System.Globalization;
using FileStore.Server.DTOs.User;
using FileStore.Server.Services;
using FileStore.Server.Services.Interfaces;
using FileStore.Server.Validators.User;
using FluentValidation;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;

namespace FileStore.Server.Configuration;

public static class DependencyInjectionConfiguration
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        
        services.AddScoped<IJwtProvider, JwtProvider>();
    }

    public static void AddValidators(this IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation(_ => 
            ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("en-US"));
        
        services.AddScoped<IValidator<CreateUserRequest>, CreateUserRequestValidator>();
    }
}