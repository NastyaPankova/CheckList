namespace Api.Configuration;

using Api.Middlewares;

public static class MiddlewaresConfiguration
{
    public static IApplicationBuilder UseAppMiddlewares(this IApplicationBuilder app)
    {
        // ToDo: connection for all Middleware using
        return app.UseMiddleware<ExceptionsMiddleware>();
    }
}