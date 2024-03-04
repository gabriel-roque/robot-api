using RobotApi.Models;

namespace RobotApi.Interfaces.Services;

public interface IRobotService
{
    Task<Robot> Get(Guid robotId);
    Task<Robot> Create(Robot robot);
    Task<IEnumerable<Robot>> List(int skip, int take = 10);
}