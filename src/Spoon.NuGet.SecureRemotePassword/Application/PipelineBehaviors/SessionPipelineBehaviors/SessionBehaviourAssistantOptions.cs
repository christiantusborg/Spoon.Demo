namespace Spoon.NuGet.SecureRemotePassword.Application.PipelineBehaviors.SessionPipelineBehaviors;

public class SessionBehaviourAssistantOptions
{
    public bool ConfigManual { get; set; } = false;
    public bool UseLogInterceptor { get; set; } = true;
}