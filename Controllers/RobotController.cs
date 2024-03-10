using System.Net.Mime;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RobotApi.Dtos;
using RobotApi.Interfaces.Services;
using RobotApi.Models;

namespace RobotApi.Controllers;

[ApiController]
[Route("robots")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class RobotController : ControllerBase
{

    [HttpGet]
    [Route("/test")]
    public async Task<IActionResult> Test()
    {
        return Ok();
    }
    
    [HttpGet]
    [Route("/admin-user")]
    [Authorize(Roles = "Admin, User")]
    public async Task<IActionResult> AdminAndUser()
    {
        
        return Ok();
    }
    
    // private readonly IRobotService _robotService;
    // private readonly IMapper _mapper;
    //
    // public RobotController(
    //     IRobotService robotService,
    //     IMapper mapper
    // )
    // {
    //     _robotService = robotService;
    //     _mapper = mapper;
    // }
    //
    // [HttpGet("", Name = "GetRobots")]
    // [Consumes(MediaTypeNames.Application.Json)]
    // [ProducesResponseType(StatusCodes.Status200OK)]
    // [ProducesResponseType(StatusCodes.Status400BadRequest)]
    // public async Task<ActionResult<IEnumerable<Robot>>> GetRobots()
    // {
    //     IEnumerable<Robot> robots = await _robotService.List(0, 20);
    //     return Ok(robots);
    // }
    //
    // [HttpGet("{id}", Name = "GetRobot")]
    // [Consumes(MediaTypeNames.Application.Json)]
    // [ProducesResponseType(StatusCodes.Status200OK)]
    // [ProducesResponseType(StatusCodes.Status404NotFound)]
    // [ProducesResponseType(StatusCodes.Status400BadRequest)]
    // public async Task<ActionResult<Robot>> GetRobot([FromRoute] string id)
    // {
    //     try
    //     {
    //         Guid.TryParse(id, out var robotId);
    //         Robot robot = await _robotService.Get(robotId);
    //
    //         if (robot is null) return NotFound();
    //
    //         return Ok(robot);
    //     }
    //     catch (Exception e)
    //     {
    //         return BadRequest(e);
    //     }
    // }
    //
    // [HttpPost("", Name = "CreateRobot")]
    // [Consumes(MediaTypeNames.Application.Json)]
    // [ProducesResponseType(StatusCodes.Status201Created)]
    // [ProducesResponseType(StatusCodes.Status400BadRequest)]
    // [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    // public async Task<ActionResult<Robot>> CreateRobot([FromBody] RobotDto body)
    // {
    //     Robot robot = _mapper.Map<Robot>(body);
    //
    //     try
    //     {
    //         await _robotService.Create(robot);
    //         return new ObjectResult(robot) { StatusCode = StatusCodes.Status201Created };
    //     }
    //     catch (Exception e)
    //     {
    //         return BadRequest(e);
    //     }
    // }
}
