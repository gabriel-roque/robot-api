using RobotApi.Models;

namespace RobotApi.Interfaces.Repositories;

public interface IRobotRepository
{
    Task<Robot> Get(Guid robotId);
    Task<Robot> Create(Robot robot);
    Task<Robot> Update(Robot robot);
    Task<IEnumerable<Robot>> List(int skip, int take = 10);
}