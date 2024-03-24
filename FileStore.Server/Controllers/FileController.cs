using FileStore.Server.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FileStore.Server.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class FileController(IFileService fileService) : ControllerBase
{
    
}