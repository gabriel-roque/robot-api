using RobotApi.Interfaces.Repository;
using RobotApi.Repositories;

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

    public static IServiceCollection AddRepositoriesDI(this IServiceCollection services)
    {
        services.AddTransient<IRobotRepository, RobotRepository>();

        return services;
    }
}