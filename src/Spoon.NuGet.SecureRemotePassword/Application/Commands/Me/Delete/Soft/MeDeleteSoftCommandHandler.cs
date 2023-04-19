namespace Spoon.NuGet.SecureRemotePassword.Application.Commands.Me.Delete.Soft;

using Core;
using Core.Application;
using Domain.Entities;
using Domain.Repositories;
using Services;

/// <summary>
///     Class ProductCreateQueryHandler. This class cannot be inherited.
/// </summary>
public sealed class MeDeleteSoftCommandHandler : IRequestHandler<MeDeleteSoftCommand, Either<MeDeleteSoftCommandResult>>
{
    private readonly IMockbleDateTime _mockbleDateTime;
    private readonly ISecureRemotePasswordRepository _repository;
    private readonly ISecureRemotePasswordService _secureRemotePasswordService;

    /// <summary>
    /// </summary>
    /// <param name="mockbleDateTime"></param>
    /// <param name="repository"></param>
    /// <param name="secureRemotePasswordService"></param>
    public MeDeleteSoftCommandHandler(IMockbleDateTime mockbleDateTime, ISecureRemotePasswordRepository repository, ISecureRemotePasswordService secureRemotePasswordService)
    {
        this._mockbleDateTime = mockbleDateTime;
        this._repository = repository;
        this._secureRemotePasswordService = secureRemotePasswordService;
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
    public async Task<Either<MeDeleteSoftCommandResult>> Handle(
        MeDeleteSoftCommand request,
        CancellationToken cancellationToken)
    {
        var existingUser = await this._repository.Users.GetAsync(new DefaultGetSpecification<User>(request.UserId), cancellationToken);
        if (existingUser == null)
            return EitherHelper<MeDeleteSoftCommandResult>.EntityNotFound(typeof(User));

        if (this._secureRemotePasswordService.IsAdministrator(existingUser))
            return EitherHelper<MeDeleteSoftCommandResult>.Create("BadPermissions_CannotDeleteYourself_YourAnAdministrator", BaseHttpStatusCodes.Status403Forbidden);

        existingUser.UpdatedAt = this._mockbleDateTime.UtcNow;
        existingUser.DeletedAt = this._mockbleDateTime.UtcNow;

        await this._repository.SaveChangesAsync(cancellationToken);

        return new Either<MeDeleteSoftCommandResult>(new MeDeleteSoftCommandResult());
    }
}