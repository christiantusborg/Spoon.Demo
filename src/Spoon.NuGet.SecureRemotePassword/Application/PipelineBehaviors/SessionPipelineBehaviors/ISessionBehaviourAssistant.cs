namespace Spoon.NuGet.SecureRemotePassword.Application.PipelineBehaviors.SessionPipelineBehaviors;

using Domain.Entities;

public interface ISessionBehaviourAssistant
{
    Guid GetSessionId();
    Task<Session?> GetSession(Guid sessionId, CancellationToken cancellationToken);
    TResponse GetInValidResponse<TRequest, TResponse>(TRequest request) where TRequest : IRequest<TResponse>;
    TResponse GetSessionNotFoundResponse<TRequest, TResponse>(TRequest request) where TRequest : IRequest<TResponse>;
    Task<bool> IsSessionValid(Session session, CancellationToken cancellationToken);
}