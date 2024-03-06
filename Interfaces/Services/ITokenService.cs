using RobotApi.Models;

namespace RobotApi.Interfaces.Services;

public interface ITokenService
{
    string Generate (User user);
}