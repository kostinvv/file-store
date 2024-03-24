using FileStore.Server.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FileStore.Server.Controllers;

[Route("api/v1/buckets")]
[ApiController]
public class BucketController(IBucketService bucketService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateBucketAsync()
    {
        await bucketService
            .CreateBucketIfNotExistsAsync()
            .ConfigureAwait(false);

        return Ok();
    }
}