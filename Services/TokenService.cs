using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using RobotApi.Interfaces.Services;
using RobotApi.Models;

namespace RobotApi.Services;

public class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;

    public TokenService(
        IConfiguration configuration
    )
    {
        _configuration = configuration;
    }
    
    public string Generate(User user)
    {
        var handler = new JwtSecurityTokenHandler();
        
        var KEY = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("Secrets:JWT_SECRET"));

        var credentials = new SigningCredentials(
            new SymmetricSecurityKey(KEY), 
            SecurityAlgorithms.HmacSha256Signature);

        var tokenDescripter = new SecurityTokenDescriptor()
        {
            Subject = GenerateClaims(user),
            SigningCredentials = credentials,
            Expires = DateTime.UtcNow.AddHours(2)
        };

        var token = handler.CreateToken(tokenDescripter);

        return handler.WriteToken(token);
    }

    private static ClaimsIdentity GenerateClaims(User user)
    {
        var ci = new ClaimsIdentity();
        
        ci.AddClaim(new Claim(ClaimTypes.Email, user.Email));
        ci.AddClaim(new Claim("user_id", user.Id.ToString()));

        return ci;
    }
}