using Microsoft.AspNetCore.Identity;

namespace RobotApi.Models;

public class User : IdentityUser
{
    public string? Name { get; set; }
}