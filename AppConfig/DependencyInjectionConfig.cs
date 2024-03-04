namespace RobotApi.AppConfig;

public class DependencyInjectionConfig
{
    public static IServiceCollection AddDatabasesConfigDI(
        IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddNpgsqlDataSource(configuration.GetConnectionString("RobotDb")!, ServiceLifetime.Singleton);

        return services;
    }
}