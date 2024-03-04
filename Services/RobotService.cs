using RobotApi.Interfaces.Repository;
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
    
    public async Task<Robot> Get(Guid robotId)
    {
        throw new NotImplementedException();
    }

    public async Task<Robot> Create(Robot robot)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Robot>> List(int skip, int take = 10) => await _robotRepository.List(skip, take);

}