using FluentValidation;

namespace FileStore.Server.DTOs.User;

public record UserLoginRequest(string Name, string Password);
    
public class UserLoginRequestValidator : AbstractValidator<UserLoginRequest>
{
    public UserLoginRequestValidator()
    {
        RuleFor(user => user.Name)
            .NotEmpty()
            .NotNull();
        
        RuleFor(user => user.Password)
            .NotEmpty()
            .NotNull();
    }
}