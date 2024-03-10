using System.Net.Mime;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RobotApi.Dtos;
using RobotApi.Enums;
using RobotApi.Interfaces.Services;
using RobotApi.Models;

namespace RobotApi.Controllers;

[ApiController]
[Route("robots")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class RobotController (
    IRobotService robotService,
    IMapper mapper
    ) : ControllerBase
{
    
    [HttpGet("")]
    [Authorize(Roles = $"{Roles.USER}, {Roles.ADMIN}")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Robot>>> GetRobots()
    {
        IEnumerable<Robot> robots = await robotService.List(0, 20);
        return Ok(robots);
    }
    
    [HttpGet("{id}")]
    [Authorize(Roles = $"{Roles.USER}, {Roles.ADMIN}")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Robot>> GetRobot([FromRoute] string id)
    {
        try
        {
            Guid.TryParse(id, out var robotId);
            Robot robot = await robotService.Get(robotId);
    
            if (robot is null) return NotFound();
    
            return Ok(robot);
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }
    
    [HttpPost("")]
    [Authorize(Roles = $"{Roles.ADMIN}")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public async Task<ActionResult<Robot>> CreateRobot([FromBody] RobotDto body)
    {
        Robot robot = mapper.Map<Robot>(body);
    
        try
        {
            await robotService.Create(robot);
            return new ObjectResult(robot) { StatusCode = StatusCodes.Status201Created };
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }
}
