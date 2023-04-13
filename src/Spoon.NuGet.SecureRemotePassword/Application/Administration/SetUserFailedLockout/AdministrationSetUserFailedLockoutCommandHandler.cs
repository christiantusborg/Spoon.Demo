// ReSharper disable ClassNeverInstantiated.Global
namespace Spoon.NuGet.SecureRemotePassword.Application.Administration.SetUserFailedLockout;

using Core;
using Core.Application;
using Domain.Entities;
using Domain.Repositories;
using EitherCore;
using EitherCore.Helpers;
using MediatR;

/// <summary>
///     Class ProductCreateQueryHandler. This class cannot be inherited.
/// </summary>
public sealed class AdministrationSetUserFailedLockoutCommandHandler : IRequestHandler<AdministrationSetUserFailedLockoutCommand, Either<AdministrationSetUserFailedLockoutCommandResult>>
{
    private readonly IMockbleDateTime _mockbleDateTime;
    private readonly ISecureRemotePasswordRepository _repository;

    /// <summary>
    /// </summary>
    /// <param name="mockbleDateTime"></param>
    /// <param name="repository"></param>
    public AdministrationSetUserFailedLockoutCommandHandler(IMockbleDateTime mockbleDateTime, ISecureRemotePasswordRepository repository)
    {
        this._mockbleDateTime = mockbleDateTime;
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
    public async Task<Either<AdministrationSetUserFailedLockoutCommandResult>> Handle(
        AdministrationSetUserFailedLockoutCommand request,
        CancellationToken cancellationToken)
    {
        var existingUser = await this._repository.Users.GetAsync(new DefaultGetSpecification<User>(request.UserId), cancellationToken);
        if (existingUser == null)
            return EitherHelper<AdministrationSetUserFailedLockoutCommandResult>.EntityNotFound(typeof(User));

        existingUser.LockoutEnd = request.Value ? null : this._mockbleDateTime.UtcNow;
        existingUser.LockoutCount = 0;
        existingUser.UpdatedAt = this._mockbleDateTime.UtcNow;

        return new Either<AdministrationSetUserFailedLockoutCommandResult>(new AdministrationSetUserFailedLockoutCommandResult());
    }
}