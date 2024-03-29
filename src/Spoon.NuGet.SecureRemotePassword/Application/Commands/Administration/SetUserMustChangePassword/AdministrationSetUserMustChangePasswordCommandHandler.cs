﻿// ReSharper disable ClassNeverInstantiated.Global

namespace Spoon.NuGet.SecureRemotePassword.Application.Commands.Administration.SetUserMustChangePassword;

using Core;
using Core.Application;
using Domain.Entities;
using Domain.Repositories;

/// <summary>
///     Class ProductCreateQueryHandler. This class cannot be inherited.
/// </summary>
public sealed class AdministrationSetUserMustChangePasswordCommandHandler : IRequestHandler<AdministrationSetUserMustChangePasswordCommand, Either<AdministrationSetUserMustChangePasswordCommandResult>>
{
    private readonly IMockbleDateTime _mockbleDateTime;
    private readonly ISecureRemotePasswordRepository _repository;

    /// <summary>
    /// </summary>
    /// <param name="mockbleDateTime"></param>
    /// <param name="repository"></param>
    public AdministrationSetUserMustChangePasswordCommandHandler(IMockbleDateTime mockbleDateTime, ISecureRemotePasswordRepository repository)
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
    public async Task<Either<AdministrationSetUserMustChangePasswordCommandResult>> Handle(
        AdministrationSetUserMustChangePasswordCommand request,
        CancellationToken cancellationToken)
    {
        var existingUser = await this._repository.Users.GetAsync(new DefaultGetSpecification<User>(request.UserId), cancellationToken);
        if (existingUser == null)
            return EitherHelper<AdministrationSetUserMustChangePasswordCommandResult>.EntityNotFound(typeof(User));

        existingUser.MustChangePassword = request.Value ? null : this._mockbleDateTime.UtcNow;
        existingUser.UpdatedAt = this._mockbleDateTime.UtcNow;

        return new Either<AdministrationSetUserMustChangePasswordCommandResult>(new AdministrationSetUserMustChangePasswordCommandResult());
    }
}