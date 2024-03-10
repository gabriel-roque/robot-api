using RobotApi.Dtos;

namespace RobotApi.Interfaces.Repositories;

public interface IUserAccountService
{
    Task<ServiceResponse.CreateAccount> CreateAccount(UserDto userDto);
    Task<ServiceResponse.LoginResponse> LoginAccount(LoginDto loginDto);
}