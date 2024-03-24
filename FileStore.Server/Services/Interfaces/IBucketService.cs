namespace FileStore.Server.Services.Interfaces;

public interface IBucketService
{
    public Task CreateBucketIfNotExistsAsync();
}