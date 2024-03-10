using Microsoft.EntityFrameworkCore;
using RobotApi.AppConfig.Maps;

namespace RobotApi.AppConfig;

public static class Map
{
    public static void Setup(ModelBuilder builder)
    {
        RobotMap.Map(builder);
    }
}