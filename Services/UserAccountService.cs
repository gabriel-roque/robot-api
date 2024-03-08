using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using RobotApi.Dtos;
using RobotApi.Interfaces.Repositories;
using RobotApi.Models;

namespace RobotApi.Services;

public class UserAccountService(
    UserManager<User> userManager,
    RoleManager<IdentityRole> roleManager,
    IConfiguration config
) : IUserAccountService
{
    public async Task<ServiceResponse.GeneralResponse> CreateAccount(UserDto userDto)
    {
        if (userDto is null) return new ServiceResponse.GeneralResponse(false, "Model is empty");
        
        var newUser = new User()
        {
            Name = userDto.Name,
            Email = userDto.Email,
            PasswordHash = userDto.Password,
            UserName = userDto.Email
        };
        
        var user = await userManager.FindByEmailAsync(newUser.Email);
        if (user is not null) return new ServiceResponse.GeneralResponse(false, "User registered already");

        var createUser = await userManager.CreateAsync(newUser!, userDto.Password);
        if (!createUser.Succeeded) return new ServiceResponse.GeneralResponse(false, "Error occured.. please try again");

        //Assign Default Role : Admin to first registrar; rest is user
        // TODO: Refactor CONST ROLES
        var checkAdmin = await roleManager.FindByNameAsync("Admin");
        if (checkAdmin is null)
        {
            await roleManager.CreateAsync(new IdentityRole() { Name = "Admin" });
            await userManager.AddToRoleAsync(newUser, "Admin");
            return new ServiceResponse.GeneralResponse(true, "Account Created");
        }
        else
        {
            var checkUser = await roleManager.FindByNameAsync("User");
            if (checkUser is null)
                await roleManager.CreateAsync(new IdentityRole() { Name = "User" });

            await userManager.AddToRoleAsync(newUser, "User");
            return new ServiceResponse.GeneralResponse(true, "Account Created");
        }
    }

    public async Task<ServiceResponse.LoginResponse> LoginAccount(LoginDto loginDto)
    {
        if (loginDto == null)
            return new ServiceResponse.LoginResponse(false, null!, "Login container is empty");

        var getUser = await userManager.FindByEmailAsync(loginDto.Email);
        if (getUser is null)
            return new ServiceResponse.LoginResponse(false, null!, "User not found");

        bool checkUserPasswords = await userManager.CheckPasswordAsync(getUser, loginDto.Password);
        if (!checkUserPasswords)
            return new ServiceResponse.LoginResponse(false, null!, "Invalid email/password");

        var getUserRole = await userManager.GetRolesAsync(getUser);
        var userSession = new UserSession(getUser.Id, getUser.Name, getUser.Email, getUserRole.First());
        string token = GenerateToken(userSession);
        return new ServiceResponse.LoginResponse(true, token!, "Login completed");
    }
    
    private string GenerateToken(UserSession user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]!));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var userClaims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Name, user.Name),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, user.Role)
        };
        var token = new JwtSecurityToken(
            issuer: config["Jwt:Issuer"],
            audience: config["Jwt:Audience"],
            claims: userClaims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: credentials
        );
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}