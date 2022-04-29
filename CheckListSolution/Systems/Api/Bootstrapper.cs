namespace Api;

using Microsoft.Extensions.DependencyInjection;
using Settings.Interface;
using CheckListService;

public static class Bootstrapper
{
    public static IServiceCollection AddAppServices(this IServiceCollection services)
    {
        services.AddSettings();
        services.AddCheckListService();
        return services;
    }
}
