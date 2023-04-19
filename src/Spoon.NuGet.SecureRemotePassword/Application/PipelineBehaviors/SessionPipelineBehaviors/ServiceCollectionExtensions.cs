namespace Spoon.NuGet.SecureRemotePassword.Application.PipelineBehaviors.SessionPipelineBehaviors;

using Core.LogInterceptor;
using Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection SessionBehaviour(this IServiceCollection services, Action<SessionBehaviourOptions>? optionsAction = null)
    {
        var options = new SessionBehaviourOptions();
        optionsAction?.Invoke(options);

        if (!options.SessionBehaviourOptionsAssistantOptions.ConfigManual)
        {
            if (options.SessionBehaviourOptionsAssistantOptions.UseLogInterceptor)
                services.AddInterceptedSingleton<ISessionBehaviourAssistant, SessionBehaviourAssistant, LogInterceptorDefault>();
            else
                services.AddSingleton<ISessionBehaviourAssistant, SessionBehaviourAssistant>();
        }

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(SessionPipelineBehavior<,>));

        return services;
    }
}