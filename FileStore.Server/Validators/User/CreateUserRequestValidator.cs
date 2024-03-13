using FileStore.Server.DTOs.User;
using FluentValidation;

namespace FileStore.Server.Validators.User
{
    public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
    {
        public CreateUserRequestValidator()
        {
            RuleFor(user => user.Name)
                .NotEmpty()
                .NotNull();

            RuleFor(user => user.Email)
                .NotEmpty()
                .NotNull()
                .EmailAddress();

            RuleFor(user => user.Password)
                .NotEmpty()
                .NotNull();

            RuleFor(user => user.Password)
                .Equal(user => user.PasswordConfirm)
                .WithMessage("Passwords must match");
        }
    }
}
