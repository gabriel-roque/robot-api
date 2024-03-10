using Microsoft.EntityFrameworkCore;
using RobotApi.Interfaces.Repositories;
using RobotApi.Interfaces.Services;
using RobotApi.Services;

namespace RobotApi.AppConfig;

public static class DependencyInjectionConfig
{
    public static IServiceCollection AddDatabasesConfigDI(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("RobotDB") ??
                throw new InvalidOperationException("Connection String is not found"));
        });
        
        // services.AddNpgsqlDataSource(configuration.GetConnectionString("RobotDb")!, ServiceLifetime.Singleton);

        return services;
    }

    public static IServiceCollection AddApplicationServicesDI(this IServiceCollection services)
    {
        // services.AddTransient<IRobotService, RobotService>();
        services.AddTransient<ITokenService, TokenService>();
        services.AddScoped<IUserAccountService, UserAccountService>();
        
        return services;
    }

    public static IServiceCollection AddRepositoriesDI(this IServiceCollection services)
    {
        // services.AddTransient<IRobotRepository, RobotRepository>();

        return services;
    }
}