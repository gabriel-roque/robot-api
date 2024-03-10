namespace RobotApi.Dtos;

public class ServiceResponse
{
    public record class CreateAccount(string message);
    public record class LoginResponse(string token, string message);
}