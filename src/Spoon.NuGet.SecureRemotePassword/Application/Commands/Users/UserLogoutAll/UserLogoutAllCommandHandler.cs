namespace Spoon.NuGet.SecureRemotePassword.Application.Commands.Users.UserLogoutAll;

using Domain.Repositories;

/// <summary>
///     Class ProductCreateQueryHandler. This class cannot be inherited.
/// </summary>
public sealed class UserLogoutAllCommandHandler : IRequestHandler<UserLogoutAllCommand, Either<UserLogoutAllCommandResult>>
{
    private readonly ISecureRemotePasswordRepository _repository;

    /// <summary>
    /// </summary>
    /// <param name="repository"></param>
    public UserLogoutAllCommandHandler(ISecureRemotePasswordRepository repository)
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
    public async Task<Either<UserLogoutAllCommandResult>> Handle(
        UserLogoutAllCommand request,
        CancellationToken cancellationToken)
    {
        var session = await this._repository.Sessions.SearchAsync(new UserLogoutAllGetSpecification(request.UserId), cancellationToken);


        foreach (var next in session)
        {
            this._repository.Sessions.Remove(next);
        }

        await this._repository.SaveChangesAsync(cancellationToken);

        return new Either<UserLogoutAllCommandResult>(new UserLogoutAllCommandResult());
    }
}