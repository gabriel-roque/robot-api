using Dapper;
using Dapper.Contrib.Extensions;
using Npgsql;
using RobotApi.Interfaces.Repository;
using RobotApi.Models;

namespace RobotApi.Repositories;

public class RobotRepository(NpgsqlConnection database): IRobotRepository
{
    private readonly NpgsqlDataSource _database;
    
    public async Task<Robot> Get(Guid robotId)
    {
        var robot = await database.GetAsync<Robot>(robotId);

        // Alternative RAW SQL
        // const string sql = "SELECT * FROM robots r WHERE r.Id = @robotId";
        // Robot robot = await database.QueryFirstAsync<Robot?>(sql, new { robotId });

        return robot;
    }

    public async Task<Robot> Create(Robot robot)
    {
        robot.Id = Guid.NewGuid();
        const string sql = "INSERT INTO robots (id, name) VALUES (@id, @name)";
        
        var result = await database.ExecuteAsync(sql, new { id = robot.Id, name = robot.Name });
        
        if(result >= 1)
            return await Get(robot.Id);
        
        return null;
    }

    public async Task<IEnumerable<Robot>> List(int skip, int take = 10)
    {
        const string sql = "SELECT * FROM robots LIMIT @take OFFSET @skip";
        
        IEnumerable<Robot> robots = await database.QueryAsync<Robot>(sql, new { skip, take });

        return robots;
    }
}