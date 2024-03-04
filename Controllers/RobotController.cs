using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using RobotApi.Interfaces.Repository;
using RobotApi.Models;

namespace RobotApi.Controllers;

[ApiController]
[Route("robots")]
public class RobotController : ControllerBase
{
    private readonly IRobotRepository _robotRepository;

    public RobotController(
        IRobotRepository robotRepository
    )
    {
        _robotRepository = robotRepository;
    }

    [HttpGet("", Name = "GetRobots")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Robot>>> GetRobots()
    {
        IEnumerable<Robot> robots = await _robotRepository.List(0, 20);
        return Ok(robots);
    }
}
