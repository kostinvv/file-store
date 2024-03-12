using Microsoft.AspNetCore.Mvc;

namespace FileStore.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public IActionResult SignUp()
        {
            return Ok();
        }

        public IActionResult SignIn()
        {
            return Ok();
        }

        public IActionResult LogOut()
        {
            return Ok();
        }
    }
}
