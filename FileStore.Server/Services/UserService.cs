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
        private readonly ApplicationDbContext _context = context;

        public async Task<Result> CreateUserAsync(CreateUserRequest request)
        {
            var foundUser = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(user => user.Name == request.Name);

            if (foundUser is not null)
            {
                return Result.Failure(UserErrors.UserAlreadyExists);
            }

            var passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            await _context.Users.AddAsync(new ApplicationUser { 
                Name = request.Name,
                Email = request.Email, 
                PasswordHash = passwordHash, 
            });
            await _context.SaveChangesAsync();

            return Result.Success();
        }

        public async Task<Result<UserLoginResponse>> LoginUserAsync(UserLoginRequest request)
        {
            var user = await _context.Users
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
