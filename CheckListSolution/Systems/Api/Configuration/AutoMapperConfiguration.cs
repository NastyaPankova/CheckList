namespace Api.Configuration;

using Common.Helpers;

public static class AutoMapperConfiguration
{
    public static IServiceCollection AddAutoMappers(this IServiceCollection services)
    {
        AutoMappersRegisterHelper.Register(services);

        return services;
    }
}