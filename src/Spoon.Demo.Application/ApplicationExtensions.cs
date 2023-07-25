namespace Spoon.Demo.Application;

using Microsoft.Extensions.DependencyInjection;
using NuGet.Core.Application.Mediator.PipelineBehaviors.AuditLog;
using NuGet.SecureRemotePassword.Helpers;

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

        app.AddMockble();

        app.AddValidationPipelineBehaviour();
        app.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

        app.AddTransient<IEncryptionService, EncryptionService>();
        app.AddAuditLogPipelineBehaviour();
        app.AddAuditLogPipelineBehaviourDefault();

        app.AddPermissionPipelineBehaviour();
        app.AddPermissionPipelineBehaviourClaimManagerAlwaysTrueDefault();

       

        return app;
    }
}