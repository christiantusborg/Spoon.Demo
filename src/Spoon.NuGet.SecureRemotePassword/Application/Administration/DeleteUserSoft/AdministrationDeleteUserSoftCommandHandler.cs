namespace Spoon.NuGet.SecureRemotePassword.Application.Administration.DeleteUserSoft;

using Core;
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
public sealed class AdministrationDeleteUserSoftCommandHandler : IRequestHandler<AdministrationDeleteUserSoftCommand, Either<AdministrationDeleteUserSoftCommandResult>>
{
    private readonly ISecureRemotePasswordRepository _repository;
    private readonly IMockbleDateTime _mockbleDateTime;


    /// <summary>
    /// </summary>
    /// <param name="repository"></param>
    /// <param name="mockbleDateTime"></param>
    public AdministrationDeleteUserSoftCommandHandler(ISecureRemotePasswordRepository repository, IMockbleDateTime mockbleDateTime)
    {
        this._repository = repository;
        this._mockbleDateTime = mockbleDateTime;
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
    public async Task<Either<AdministrationDeleteUserSoftCommandResult>> Handle(
        AdministrationDeleteUserSoftCommand request,
        CancellationToken cancellationToken)
    {
        var existingUser = await this._repository.Users.GetAsync(new DefaultGetSpecification<User>(request.UserId), cancellationToken);
        if (existingUser == null)
            return EitherHelper<AdministrationDeleteUserSoftCommandResult>.EntityNotFound(typeof(User));

        if (request.UserId == request.CurrentUserId)
            return EitherHelper<AdministrationDeleteUserSoftCommandResult>.Create("BadPermissions_CannotDeleteYourself", BaseHttpStatusCodes.Status403Forbidden);

        existingUser.DeletedAt = this._mockbleDateTime.UtcNow;

        await this._repository.SaveChangesAsync(cancellationToken);

        return new Either<AdministrationDeleteUserSoftCommandResult>(new AdministrationDeleteUserSoftCommandResult());
    }
}