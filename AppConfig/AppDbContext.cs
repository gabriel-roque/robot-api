using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RobotApi.Models;

namespace RobotApi.AppConfig;

public class AppDbContext(DbContextOptions options) : IdentityDbContext<User>(options)
{
    public DbSet<Robot> Robot { get; set; }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        foreach (var entityType in builder.Model.GetEntityTypes())
        {
            var tableName = entityType.GetTableName();
            if (tableName.StartsWith("AspNet"))
                entityType.SetTableName(tableName.Substring(6));
            
            Map.Setup(builder);
        }
    }
}
