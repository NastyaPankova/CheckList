namespace CheckListService;

using Microsoft.Extensions.DependencyInjection;

public static class Bootstrapper
{
    public static IServiceCollection AddCheckListService(this IServiceCollection services)
    {
        services.AddSingleton<ICheckListService, CheckListService>();

        return services;
    }
}