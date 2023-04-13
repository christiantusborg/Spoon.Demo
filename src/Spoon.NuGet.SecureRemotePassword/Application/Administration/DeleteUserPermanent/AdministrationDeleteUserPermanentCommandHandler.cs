namespace Spoon.NuGet.SecureRemotePassword.Application.Administration.DeleteUserPermanent;

using Core.Application;
using Domain.Entities;
using Domain.Repositories;
using EitherCore;
using EitherCore.Enums;
using EitherCore.Helpers;
using MediatR;

/// <summary>
///     Class ProductCreateQueryHandler. This class cannot be inherited.
/// </summary>
// ReSharper disable once ClassNeverInstantiated.Global
public sealed class AdministrationDeleteUserPermanentCommandHandler : IRequestHandler<AdministrationDeleteUserPermanentCommand, Either<AdministrationDeleteUserPermanentCommandResult>>
{
    private readonly ISecureRemotePasswordRepository _repository;

    /// <summary>
    /// </summary>
    /// <param name="repository"></param>
    public AdministrationDeleteUserPermanentCommandHandler(ISecureRemotePasswordRepository repository)
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
    public async Task<Either<AdministrationDeleteUserPermanentCommandResult>> Handle(
        AdministrationDeleteUserPermanentCommand request,
        CancellationToken cancellationToken)
    {
        var existingUser = await this._repository.Users.GetAsync(new DefaultGetSpecification<User>(request.UserId), cancellationToken);
        if (existingUser == null)
            return EitherHelper<AdministrationDeleteUserPermanentCommandResult>.EntityNotFound(typeof(User));

        if (request.UserId == request.CurrentUserId)
            return EitherHelper<AdministrationDeleteUserPermanentCommandResult>.Create("BadPermissions_CannotDeleteYourself", BaseHttpStatusCodes.Status403Forbidden);


        this._repository.Users.Remove(existingUser);

        await this._repository.SaveChangesAsync(cancellationToken);

        return new Either<AdministrationDeleteUserPermanentCommandResult>(new AdministrationDeleteUserPermanentCommandResult());
    }
}