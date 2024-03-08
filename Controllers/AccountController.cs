using Microsoft.AspNetCore.Mvc;
using RobotApi.Dtos;
using RobotApi.Interfaces.Repositories;

namespace RobotApi.Controllers;

[ApiController]
[Route("accounts")]
public class AccountController(IUserAccountService userAccountService) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> Register(UserDto userDto)
    {
        var response = await userAccountService.CreateAccount(userDto);
        return Ok(response);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto loginDTO)
    {
        var response = await userAccountService.LoginAccount(loginDTO);
        return Ok(response);
    }
}
