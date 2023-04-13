namespace Spoon.NuGet.SecureRemotePassword.Application.Users.ConfirmEmail;

using Core;
using Core.Application;
using Domain.Entities;
using Domain.Repositories;
using EitherCore;
using EitherCore.Enums;
using EitherCore.Helpers;
using MediatR;
using Microsoft.Extensions.Configuration;

/// <summary>
///     Class ProductCreateQueryHandler. This class cannot be inherited.
/// </summary>
public sealed class UserConfirmEmailCommandHandler : IRequestHandler<UserConfirmEmailCommand, Either<UserConfirmEmailCommandResult>>
{
    private readonly ISecureRemotePasswordRepository _repository;
    private readonly IMockbleDateTime _mockbleDateTime;
    private readonly IConfiguration _configuration;

    /// <summary>
    /// </summary>
    /// <param name="repository"></param>
    /// <param name="mockbleDateTime"></param>
    /// <param name="configuration"></param>
    public UserConfirmEmailCommandHandler(ISecureRemotePasswordRepository repository, IMockbleDateTime mockbleDateTime, IConfiguration configuration)
    {
        this._repository = repository;
        this._mockbleDateTime = mockbleDateTime;
        this._configuration = configuration;
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
    public async Task<Either<UserConfirmEmailCommandResult>> Handle(
        UserConfirmEmailCommand request,
        CancellationToken cancellationToken)
    {
        var existingUserEmail = await this._repository.UserEmailConfirms.GetAsync(new DefaultGetSpecification<UserEmailConfirm>(request.EmailId), cancellationToken);

        if (existingUserEmail == null)
            return EitherHelper<UserConfirmEmailCommandResult>.EntityNotFound(typeof(UserEmailConfirm));


        if (existingUserEmail.ConfirmationToken != request.ConfirmCode)
            return EitherHelper<UserConfirmEmailCommandResult>.Create("InvalidConfirmationCode", BaseHttpStatusCodes.Status401Unauthorized);

        var userEmail = await this._repository.UserEmails.GetAsync(new DefaultGetSpecification<UserEmail>(request.EmailId), cancellationToken);

        // Get the value of the ExpirationTime key
        // If the ExpirationTime key does not exist, use the current UTC date and time plus 24 hours
        int? expirationTime = this._configuration.GetValue<int?>("UserEmailConfirms:ExpirationTime") ?? 24;

        if (existingUserEmail.CreatedAt.AddHours(expirationTime.Value) <= this._mockbleDateTime.UtcNow)
            return EitherHelper<UserConfirmEmailCommandResult>.Create("ConfirmationCodeExpired", BaseHttpStatusCodes.Status419AuthenticationTimeout);

        if (userEmail == null)
            return EitherHelper<UserConfirmEmailCommandResult>.EntityNotFound(typeof(UserEmail));

        userEmail.EmailAddressVerifiedAt = this._mockbleDateTime.UtcNow;

        this._repository.UserEmailConfirms.Remove(existingUserEmail);

        await this._repository.SaveChangesAsync(cancellationToken);

        return new Either<UserConfirmEmailCommandResult>(new UserConfirmEmailCommandResult());
    }
}