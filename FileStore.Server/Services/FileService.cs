using FileStore.Server.Data;
using FileStore.Server.Interfaces;
using FileStore.Server.Services.Interfaces;

namespace FileStore.Server.Services;

public class FileService(
    ApplicationDbContext context, 
    IStorageRepository storageRepository,
    IConfiguration configuration) : IFileService
{
    
}