using RobotApi.Dtos;

namespace RobotApi.Interfaces.Services;

public interface ITokenService
{
    string Generate (UserSession user);
}