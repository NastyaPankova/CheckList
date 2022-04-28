namespace Api.Configuration;

using CheckListDbContext.Context;
using CheckListDbContext.Factories;
using Settings.Interface;
using Microsoft.Extensions.DependencyInjection;
using CheckListDbContext.Setup;

public static class DbConfiguration
{
    public static IServiceCollection AddAppDbContext(this IServiceCollection services, IApiSettings settings)
    {
        var connectionString = settings.Db.ConnectionString;
        var dbOptionsDelegate = DbContextOptionFactory.Configure(connectionString);

        services.AddDbContextFactory<MainDbContext>(dbOptionsDelegate, ServiceLifetime.Singleton);

        return services;
    }

    public static WebApplication UseAppDbContext(this WebApplication app)
    {
        DbInit.Execute(app.Services);

        DbSeed.Execute(app.Services);

        return app;
    }
}