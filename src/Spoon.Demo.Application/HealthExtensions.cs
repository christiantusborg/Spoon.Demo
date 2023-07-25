namespace Spoon.Demo.Application;

using Health;
using Microsoft.Extensions.DependencyInjection;

/// <summary>
/// 
/// </summary>
public static class HealthExtensions
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public static IServiceCollection AddHealth(this IServiceCollection app)
    {
    //    app.AddHealthChecks()
      //      .AddCheck<DatabaseHealthCheck>(DatabaseHealthCheck.Name);
        
        return app;
    }
}