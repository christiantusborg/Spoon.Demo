namespace Spoon.NuGet.SecureRemotePassword.Application.Commands.Users.UserForgotPasswordRecoverByEmailInit;

using Core;
using Core.Application;
using Domain.Entities;
using Domain.Repositories;
using Helpers;
using Services;
using SharedSpecification;

/// <summary>
///     Class ProductCreateQueryHandler. This class cannot be inherited.
/// </summary>
public sealed class UserForgotPasswordRecoverByEmailInitCommandHandler : IRequestHandler<UserForgotPasswordRecoverByEmailInitCommand, Either<UserForgotPasswordRecoverByEmailInitCommandResult>>
{
    private readonly ISecureRemotePasswordRepository _repository;
    private readonly IMockbleDateTime _mockbleDateTime;
    private readonly IHashService _hashService;
    private readonly IRandomStringService _randomStringService;


    /// <summary>
    /// </summary>
    /// <param name="mockbleDateTime"></param>
    /// <param name="repository"></param>
    /// <param name="hashService"></param>
    /// <param name="randomStringService"></param>
    public UserForgotPasswordRecoverByEmailInitCommandHandler(ISecureRemotePasswordRepository repository,
        IMockbleDateTime mockbleDateTime,
        IHashService hashService,
        IRandomStringService randomStringService)
    {
        this._repository = repository;
        this._mockbleDateTime = mockbleDateTime;
        this._hashService = hashService;
        this._randomStringService = randomStringService;
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
    public async Task<Either<UserForgotPasswordRecoverByEmailInitCommandResult>> Handle(
        UserForgotPasswordRecoverByEmailInitCommand request,
        CancellationToken cancellationToken)
    {
        var emailHashed = this._hashService.Hash(request.Email);
        var userEmail = await this._repository.UserEmails.GetAsync(new GetEmailByHashSpecification(emailHashed), cancellationToken);

        if (userEmail == null)
            return EitherHelper<UserForgotPasswordRecoverByEmailInitCommandResult>.EntityNotFound(typeof(UserEmail));

        var recoveryString = this._randomStringService.CreateRandomString(11, CharacterType.Number | CharacterType.UpperCaseLetter);

        var recoveryStringHashed = this._hashService.Hash(recoveryString);

        var emailRecovery = new SecureRemotePasswordByRecoveryEmail
        {
            UserId = userEmail.UserId,
            CreatedAt = this._mockbleDateTime.UtcNow,
            RecoveryTokenHashed = recoveryStringHashed,
        };

        var existingEmailRecovery =
            await this._repository.SecureRemotePasswordByRecoveryEmails.GetAsync(new DefaultGetSpecification<SecureRemotePasswordByRecoveryEmail>(userEmail.UserId), cancellationToken);

        if (existingEmailRecovery != null)
        {
            this._repository.SecureRemotePasswordByRecoveryEmails.Remove(existingEmailRecovery);
            await this._repository.SaveChangesAsync(cancellationToken);
        }

        this._repository.SecureRemotePasswordByRecoveryEmails.Add(emailRecovery);

        await this._repository.SaveChangesAsync(cancellationToken);

        var result = new UserForgotPasswordRecoverByEmailInitCommandResult
        {
            UserId = userEmail.UserId,
            Email = request.Email,
            RecoveryString = recoveryString,
        };

        return new Either<UserForgotPasswordRecoverByEmailInitCommandResult>(result);
    }
}