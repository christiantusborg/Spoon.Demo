namespace Spoon.NuGet.SecureRemotePassword.Application.PipelineBehaviors.SessionPipelineBehaviors;

using System.Security.Claims;
using Core;
using Core.Application;
using Core.LogInterceptor;
using Domain.Entities;
using Domain.Repositories;
using Extensions;
using Microsoft.Extensions.Logging;

[LogInterceptorDefaultLogLevel(LogLevel.Debug)]
public class SessionBehaviourAssistant : ISessionBehaviourAssistant
{
    private readonly ISecureRemotePasswordRepository _repository;
    private readonly IMockbleDateTime _mockbleDateTimer;
    private readonly ClaimsPrincipal _claimsPrincipal;

    public SessionBehaviourAssistant(ISecureRemotePasswordRepository repository, IMockbleDateTime mockbleDateTimer, ClaimsPrincipal claimsPrincipal)
    {
        this._repository = repository;
        this._mockbleDateTimer = mockbleDateTimer;
        this._claimsPrincipal = claimsPrincipal;
    }

    public Guid GetSessionId()
    {
        var sessionId = this._claimsPrincipal.GetSessionId();
        return sessionId;
    }

    public async Task<Session?> GetSession(Guid sessionId, CancellationToken cancellationToken)
    {
        var session = await this._repository.Sessions.GetAsync(new DefaultGetSpecification<Session>(sessionId), cancellationToken);
        return session;
    }


    public TResponse GetInValidResponse<TRequest, TResponse>(TRequest request) where TRequest : IRequest<TResponse>
    {
        var ext = new EitherException(request!, string.Empty, "RefreshTokenIsInvalid_Expired_And_Was_Deleted", BaseHttpStatusCodes.Status498InvalidToken, new Dictionary<string, object>());
        var response = (TResponse)Activator.CreateInstance(typeof(TResponse), ext) !;

        return response;
        ;
    }

    public TResponse GetSessionNotFoundResponse<TRequest, TResponse>(TRequest request) where TRequest : IRequest<TResponse>
    {
        var ext = new EitherException(request!, string.Empty, "RefreshTokenIsInvalid_NotFound", BaseHttpStatusCodes.Status498InvalidToken, new Dictionary<string, object>());
        var response = (TResponse)Activator.CreateInstance(typeof(TResponse), ext) !;

        return response;
        ;
    }

    public async Task<bool> IsSessionValid(Session session, CancellationToken cancellationToken)
    {
        if (session.SessionExpiresAt < this._mockbleDateTimer.UtcNow)
        {
            this._repository.Sessions.Remove(session);
            await this._repository.SaveChangesAsync(cancellationToken);
            return false;
        }

        return true;
    }
}