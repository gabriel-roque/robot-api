using RobotApi.Interfaces.Repositories;
using RobotApi.Interfaces.Services;
using RobotApi.Models;

namespace RobotApi.Services;

public class RobotService: IRobotService
{
    private readonly IRobotRepository _robotRepository;

    public RobotService(IRobotRepository robotRepository)
    {
        _robotRepository = robotRepository;
    }

    public async Task<Robot> Get(Guid robotId) => await _robotRepository.Get(robotId);

    public async Task<Robot> Create(Robot robot) => await _robotRepository.Create(robot);

    public async Task<IEnumerable<Robot>> List(int skip, int take = 10) => await _robotRepository.List(skip, take);

}