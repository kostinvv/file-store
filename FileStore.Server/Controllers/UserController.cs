using FileStore.Server.DTOs.User;
using FileStore.Server.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FileStore.Server.Controllers
{
    [Route("api/v1/user")]
    [ApiController]
    public class UserController(IUserService userService) : ControllerBase
    {
        [HttpPost("sign-up")]
        public async Task<ActionResult> SignUp(
            [FromBody] CreateUserRequest request)
        {
            var result = await userService.CreateUserAsync(request);

            if (result.IsSuccess)
            {
                return Created();
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Message);
                }
            }

            return ValidationProblem();
        }

        [AllowAnonymous]
        [HttpPost("sign-in")]
        public async Task<ActionResult<UserLoginResponse>> SignInAsync(
            [FromBody] UserLoginRequest request)
        {
            var result = await userService.LoginUserAsync(request);

            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.Code, error.Message);
            }

            return ValidationProblem();
        }

        [Authorize]
        [HttpPost("logout")]
        public IActionResult LogOut()
        {
            return Ok();
        }
    }
}
