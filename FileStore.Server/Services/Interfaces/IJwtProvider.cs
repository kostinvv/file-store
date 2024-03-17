namespace FileStore.Server.Services.Interfaces;

public interface IJwtProvider
{
    public string CreateAccessToken(string name);
}