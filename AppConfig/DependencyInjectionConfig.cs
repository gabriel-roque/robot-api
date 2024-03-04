using RobotApi.Interfaces.Repository;
using RobotApi.Interfaces.Services;
using RobotApi.Repositories;
using RobotApi.Services;

namespace RobotApi.AppConfig;

public static class DependencyInjectionConfig
{
    public static IServiceCollection AddDatabasesConfigDI(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddNpgsqlDataSource(configuration.GetConnectionString("RobotDb")!, ServiceLifetime.Singleton);

        return services;
    }

    public static IServiceCollection AddApplicationServicesDI(this IServiceCollection services)
    {
        services.AddTransient<IRobotService, RobotService>();
        
        return services;
    }

    public static IServiceCollection AddRepositoriesDI(this IServiceCollection services)
    {
        services.AddTransient<IRobotRepository, RobotRepository>();

        return services;
    }
}