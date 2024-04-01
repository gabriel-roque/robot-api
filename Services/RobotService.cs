using RobotApi.Interfaces.Repositories;
using RobotApi.Interfaces.Services;
using RobotApi.Models;

namespace RobotApi.Services;

public class RobotService (
        IRobotRepository robotRepository
    )
    : IRobotService
{
    public async Task<Robot> Get(Guid robotId) => await robotRepository.Get(robotId);
    public async Task<Robot> Create(Robot robot) => await robotRepository.Create(robot);
    public async Task<Robot> Update(Robot robot) => await robotRepository.Update(robot);
    public async Task<IEnumerable<Robot>> List(int skip, int take = 10) => await robotRepository.List(skip, take);
}