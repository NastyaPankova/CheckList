namespace Identity;

using Settings.Interface;

public static class Bootstrapper
{
    public static void AddAppServices(this IServiceCollection services)
    {
        services.AddSettings();
    }
}