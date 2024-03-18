using FileStore.Server.DTOs.User;
using FileStore.Server.Results;

namespace FileStore.Server.Services.Interfaces
{
    public interface IUserService
    {
        public Task<Result<CreateUserResponse>> CreateUserAsync(CreateUserRequest request);

        public Task<Result<UserLoginResponse>> LoginUserAsync(UserLoginRequest request);
    }
}
