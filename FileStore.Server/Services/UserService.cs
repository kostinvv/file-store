using FileStore.Server.Data;
using FileStore.Server.DTOs.User;
using FileStore.Server.Errors;
using FileStore.Server.Models;
using FileStore.Server.Results;
using FileStore.Server.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FileStore.Server.Services
{
    public class UserService(ApplicationDbContext context, IJwtProvider jwtProvider) : IUserService
    {
        public async Task<Result<CreateUserResponse>> CreateUserAsync(CreateUserRequest request)
        {
            var foundUser = await context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(user => user.Name == request.Name);
 
            if (foundUser is not null)
            {
                return Result<CreateUserResponse>.Failure(UserErrors.UserAlreadyExists);
            }

            var passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            await context.Users.AddAsync(new ApplicationUser { 
                Name = request.Name,
                Email = request.Email, 
                PasswordHash = passwordHash, 
            });
            await context.SaveChangesAsync();

            var token = jwtProvider.CreateAccessToken(request.Name);
            var response = new CreateUserResponse(request.Name, token);

            return Result<CreateUserResponse>.Success(response);
        }

        public async Task<Result<UserLoginResponse>> LoginUserAsync(UserLoginRequest request)
        {
            var user = await context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(user => user.Name == request.Name);

            if (user is null)
            {
                return Result<UserLoginResponse>.Failure(UserErrors.UserNotFound);
            }

            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            {
                return Result<UserLoginResponse>.Failure(UserErrors.WrongPassword);
            }

            var token = jwtProvider.CreateAccessToken(request.Name);

            return Result<UserLoginResponse>.Success(
                new UserLoginResponse(token));
        }
    }
}
