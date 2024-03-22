using FileStore.Server.DTOs.User;
using FileStore.Server.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FileStore.Server.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class UserController(IUserService userService) : ControllerBase
{
    private const string TokenKey = "app-token";
        
    [AllowAnonymous]
    [HttpPost]
    public async Task<ActionResult<UserResponse>> SignUpAsync(
        [FromBody] CreateUserRequest request)
    {
        var result = await userService.CreateUserAsync(request);
            
        if (result.IsSuccess)
        {
            Response.Cookies.Append(key: TokenKey, value: result.Value!.AccessToken);
            
            return Ok(result.Value);
        } 
            
        foreach (var error in result.Errors)
        {
            ModelState.AddModelError(error.Code, error.Message);
        }

        return ValidationProblem();
    }

    [AllowAnonymous]
    [HttpPost("sign-in")]
    public async Task<ActionResult<UserResponse>> SignInAsync(
        [FromBody] UserLoginRequest request)
    {
        var result = await userService.LoginUserAsync(request);

        if (result.IsSuccess)
        {
            Response.Cookies.Append(key: TokenKey, value: result.Value!.AccessToken);
                
            return Ok(result.Value);
        }

        foreach (var error in result.Errors)
        {
            ModelState.AddModelError(error.Code, error.Message);
        }

        return ValidationProblem();
    }

    [Authorize]
    [HttpGet]
    public ActionResult<CurrentUserResponse> GetCurrentUser()
    {
        var username = User.FindFirst("Username")!.Value;
        var response = new CurrentUserResponse(username);
        
        return Ok(response);
    }

    [Authorize]
    [HttpPost("logout")]
    public ActionResult LogOut()
    {
        if (Request.Cookies.ContainsKey(TokenKey))
        {
            Response.Cookies.Delete(TokenKey);   
        }
            
        return Ok();
    }
}