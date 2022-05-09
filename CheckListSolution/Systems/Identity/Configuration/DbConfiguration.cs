namespace Identity.Configuration;

using CheckListDbContext.Context;
using CheckListDbContext.Factories;
using Settings.Interface;
using Microsoft.Extensions.DependencyInjection;

public static class DbConfiguration
{
    public static IServiceCollection AddAppDbContext(this IServiceCollection services, IDbSettings settings)
    {
        var dbOptionsDelegate = DbContextOptionFactory.Configure(settings.ConnectionString);

        services.AddDbContextFactory<MainDbContext>(dbOptionsDelegate, ServiceLifetime.Singleton);

        return services;
    }

    public static IApplicationBuilder UseAppDbContext(this IApplicationBuilder app)
    {
        return app;
    }
}
