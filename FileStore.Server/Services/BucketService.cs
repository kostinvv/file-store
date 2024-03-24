using FileStore.Server.Services.Interfaces;
using Minio;
using Minio.DataModel.Args;

namespace FileStore.Server.Services;

public class BucketService(
    IMinioClient minioClient, 
    ILogger<BucketService> logger,
    IConfiguration config) : IBucketService
{
    public async Task CreateBucketIfNotExistsAsync()
    {
        var bucketName = config["Minio:BucketName"];
        
        var bucketExistsArgs = new BucketExistsArgs().WithBucket(bucketName);
        
        var bucketExists = await minioClient
            .BucketExistsAsync(bucketExistsArgs).ConfigureAwait(false);
        
        if (!bucketExists)
        {
            var makeBucketArgs = new MakeBucketArgs().WithBucket(bucketName);
            await minioClient.MakeBucketAsync(makeBucketArgs).ConfigureAwait(false);
            
            logger.LogInformation($"Created bucket {bucketName}");
        }
    }
}