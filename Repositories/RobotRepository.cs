using Dapper;
using Npgsql;
using RobotApi.Interfaces.Repository;
using RobotApi.Models;

namespace RobotApi.Repositories;

public class RobotRepository(NpgsqlConnection database): IRobotRepository
{
    private readonly NpgsqlDataSource _database;
    
    public async Task<Robot> Get()
    {
        throw new NotImplementedException();
    }

    public async Task<Robot> Create(Robot robot)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Robot>> List(int skip, int take = 10)
    {
        database.Open();
        
        const string sql = "SELECT * FROM robots LIMIT @take OFFSET @skip";
        
        IEnumerable<Robot> robots = await database.QueryAsync<Robot>(sql, new { skip, take });
        database.Close();

        return robots;
    }
}