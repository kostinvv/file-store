using FileStore.Server.DTOs.User;
using FileStore.Server.Results;

namespace FileStore.Server.Services.Interfaces
{
    public interface IUserService
    {
        public Task<Result<UserResponse>> CreateUserAsync(CreateUserRequest request);

        public Task<Result<UserResponse>> LoginUserAsync(UserLoginRequest request);
    }
}
