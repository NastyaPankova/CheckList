namespace Api.Configuration;

using Api.Middlewares;

public static class MiddlewaresConfiguration
{
    public static IApplicationBuilder UseAppMiddlewares(this IApplicationBuilder app)
    {
        // CHANGED: если несколько Middleware, то все подкючаются здесь
        return app.UseMiddleware<ExceptionsMiddleware>();
    }
}