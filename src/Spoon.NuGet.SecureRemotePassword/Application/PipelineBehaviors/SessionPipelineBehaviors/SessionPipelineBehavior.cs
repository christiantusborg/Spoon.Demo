namespace Spoon.NuGet.SecureRemotePassword.Application.PipelineBehaviors.SessionPipelineBehaviors;

using Core;
using Domain.Repositories;

public class SessionPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly ISecureRemotePasswordRepository _repository;
    private readonly IMockbleDateTime _mockbleDateTimer;
    private readonly ISessionBehaviourAssistant _sessionBehaviourAssistant;


    public SessionPipelineBehavior(ISecureRemotePasswordRepository repository, IMockbleDateTime mockbleDateTimer, ISessionBehaviourAssistant sessionBehaviourAssistant)
    {
        this._repository = repository;
        this._mockbleDateTimer = mockbleDateTimer;
        this._sessionBehaviourAssistant = sessionBehaviourAssistant;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var sessionId = this._sessionBehaviourAssistant.GetSessionId();

        var session = await this._sessionBehaviourAssistant.GetSession(sessionId, cancellationToken);

        if (session is null)
        {
            var getSessionNotFoundResponse = this._sessionBehaviourAssistant.GetSessionNotFoundResponse<TRequest, TResponse>(request);
            return getSessionNotFoundResponse;
        }

        var isSessionValid = await this._sessionBehaviourAssistant.IsSessionValid(session, cancellationToken);

        if (isSessionValid is false)
        {
            var getInValidResponse = this._sessionBehaviourAssistant.GetInValidResponse<TRequest, TResponse>(request);
            return getInValidResponse;
        }

        session.ActionAt = this._mockbleDateTimer.UtcNow;
        await this._repository.SaveChangesAsync(cancellationToken);

        return await next();
    }
}