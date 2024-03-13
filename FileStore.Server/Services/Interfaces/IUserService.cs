using FileStore.Server.DTOs.User;
using FileStore.Server.Results;

namespace FileStore.Server.Services.Interfaces
{
    public interface IUserService
    {
        public Task<Result> CreateUserAsync(CreateUserRequest request);

        public Task<UserLoginResponse> LoginUserAsync(UserLoginRequest request);
    }
}
