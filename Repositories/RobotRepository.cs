using System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using RobotApi.AppConfig;
using RobotApi.AppConfig.Errors;
using RobotApi.Interfaces.Repositories;
using RobotApi.Models;

namespace RobotApi.Repositories;

public class RobotRepository(
    AppDbContext database
    ): IRobotRepository
{
    
    public async Task<Robot> Get(Guid robotId)
    {
        var robot = await database.Robot
                .AsNoTracking()
                .FirstOrDefaultAsync(robot => robot.Id == robotId);

        return robot;
    }

    public async Task<Robot> Create(Robot robot)
    {
        database.Robot.Add(robot);

        await database.SaveChangesAsync();
        
        return robot;
    }

    public async Task<Robot> Update(Robot robot)
    {
        var robotFound =
            await database.Robot
                .FirstOrDefaultAsync((r) =>
                    r.Id == robot.Id);

        if (robotFound is null)
            throw new NotFoundException("Robot not found with version");

        robotFound.Name = robot.Name;

        database.Update(robotFound);
        
        await database.SaveChangesAsync();

        return robotFound;
    }

    public async Task<IEnumerable<Robot>> List(int skip, int take = 10)
    {
        var robots = await database.Robot.Skip(skip).Take(take).AsNoTracking().ToListAsync();

        return robots;
    }
}