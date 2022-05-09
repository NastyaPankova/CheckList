namespace Api.Configuration;

using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Reflection;

public class HealthCheckers : IHealthCheck 
{
    public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default(CancellationToken))
    {
        var assembly = Assembly.Load("Api"); // CHANGED: DSRNetSchool.API -> Api
        var versionNumber = assembly.GetName().Version;

        return HealthCheckResult.Healthy(description: $"Build {versionNumber}");
    }
}