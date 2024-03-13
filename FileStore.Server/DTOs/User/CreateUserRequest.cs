namespace FileStore.Server.DTOs.User
{
    public record CreateUserRequest(string Name, string Email, string Password, string PasswordConfirm);
}
