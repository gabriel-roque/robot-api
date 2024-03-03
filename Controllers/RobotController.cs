using Dapper;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using RobotApi.Models;

namespace RobotApi.Controllers;

[ApiController]
[Route("[controller]")]
public class RobotController : ControllerBase
{
    private readonly ILogger<RobotController> _logger;
    private readonly string _connectionString;

    public RobotController(
        ILogger<RobotController> logger,
        IConfiguration configuration
    )
    {
        _logger = logger;
        _connectionString = configuration.GetConnectionString("RobotDb");
    }

    [HttpGet(Name = "GetRobots")]
    public async Task<IActionResult> Get()
    {
        using (var db = new NpgsqlConnection(_connectionString))
        {
            db.Open();
            const string sql = "SELECT * FROM robots";
            
            var robots = await db.QueryAsync<Robot>(sql);
            db.Close();

            return Ok(robots);
        } 
    }
}
