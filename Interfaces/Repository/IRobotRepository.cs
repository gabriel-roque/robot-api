using RobotApi.Models;

namespace RobotApi.Interfaces.Repository;

public interface IRobotRepository
{
    Task<Robot> Get();
    Task<Robot> Create(Robot robot);
    Task<IEnumerable<Robot>> List(int skip, int take = 10);
}