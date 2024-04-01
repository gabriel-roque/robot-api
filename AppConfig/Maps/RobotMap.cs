using Microsoft.EntityFrameworkCore;
using RobotApi.Models;

namespace RobotApi.AppConfig.Maps;

internal static class RobotMap
{
    public static void Map(ModelBuilder modelBuilder)
    {
        modelBuilder.Map<Robot>();
        modelBuilder.Entity<Robot>(builder =>
        {
            builder.Property(p => p.Name).DefaultString(20, true);
            builder.Property(p => p.Level);
            builder.Property(p => p.Version)
                .IsConcurrencyToken();
        });
    }
}