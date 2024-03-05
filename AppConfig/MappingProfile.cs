using AutoMapper;
using RobotApi.Dtos;
using RobotApi.Models;

namespace RobotApi.AppConfig;

public class MappingProfile: Profile
{
    public MappingProfile()
    {
        CreateMap<Robot, RobotDto>();
        CreateMap<RobotDto, Robot>();
    }
}