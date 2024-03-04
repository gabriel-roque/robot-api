using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using RobotApi.Interfaces.Services;
using RobotApi.Models;

namespace RobotApi.Controllers;

[ApiController]
[Route("robots")]
public class RobotController : ControllerBase
{
    private readonly IRobotService _robotService;

    public RobotController(
        IRobotService robotService
    )
    {
        _robotService = robotService;
    }

    [HttpGet("", Name = "GetRobots")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Robot>>> GetRobots()
    {
        IEnumerable<Robot> robots = await _robotService.List(0, 20);
        return Ok(robots);
    }
}
