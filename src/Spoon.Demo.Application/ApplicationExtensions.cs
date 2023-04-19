namespace Spoon.Demo.Application;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using NuGet.Core;
using NuGet.Core.Application.Mediator.PipelineBehaviors.AuditLog;
using NuGet.Core.Application.Mediator.PipelineBehaviors.Permission;
using NuGet.Core.Application.Mediator.PipelineBehaviors.Validation;

/// <summary>
/// </summary>
public static class ApplicationExtensions
{
    /// <summary>
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public static IServiceCollection AddApplication(this IServiceCollection app)
    {
        app.AddHealth();

        app.AddCore();

        app.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

        app.AddAuditLogPipelineBehaviour();
        app.AddAuditLogPipelineBehaviourDefault();

        app.AddPermissionPipelineBehaviour();
        app.AddPermissionPipelineBehaviourClaimManagerAlwaysTrueDefault();

        app.AddValidationPipelineBehaviour();

        return app;
    }
}