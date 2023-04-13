namespace Spoon.Demo.Application;

using Domain.Repositories;
using Health;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using NuGet.Core;
using NuGet.Mediator.PipelineBehaviors.AuditLog;
using NuGet.Mediator.PipelineBehaviors.Permission;
using NuGet.Mediator.PipelineBehaviors.Validation;
using Persistence.Repositories;

/// <summary>
/// 
/// </summary>
public static class ApplicationExtensions
{
    /// <summary>
    /// 
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