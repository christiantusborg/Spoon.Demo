namespace Spoon.NuGet.SecureRemotePassword.Application.Commands.Users.UserLogout;

using Domain.Entities;
using Domain.Repositories;

/// <summary>
///     Class ProductCreateQueryHandler. This class cannot be inherited.
/// </summary>
public sealed class UserLogoutCommandHandler : IRequestHandler<UserLogoutCommand, Either<UserLogoutCommandResult>>
{
    private readonly ISecureRemotePasswordRepository _repository;

    /// <summary>
    /// </summary>
    /// <param name="repository"></param>
    public UserLogoutCommandHandler(ISecureRemotePasswordRepository repository)
    {
        this._repository = repository;
    }

    /// <summary>
    ///     Handles the specified request.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <param name="cancellationToken">
    ///     The cancellation token that can be used by other objects or threads to receive notice
    ///     of cancellation.
    /// </param>
    /// <returns>Task&lt;Either&lt;ProductCreateQueryResult&gt;&gt;.</returns>
    public async Task<Either<UserLogoutCommandResult>> Handle(
        UserLogoutCommand request,
        CancellationToken cancellationToken)
    {
        var session = await this._repository.Sessions.GetAsync(new UserLogoutGetSpecification(request.UserId, request.SessionId), cancellationToken);

        if (session == null)
            return EitherHelper<UserLogoutCommandResult>.EntityNotFound(typeof(SecureRemotePasswordLogin));

        this._repository.Sessions.Remove(session);
        await this._repository.SaveChangesAsync(cancellationToken);

        return new Either<UserLogoutCommandResult>(new UserLogoutCommandResult());
    }
}