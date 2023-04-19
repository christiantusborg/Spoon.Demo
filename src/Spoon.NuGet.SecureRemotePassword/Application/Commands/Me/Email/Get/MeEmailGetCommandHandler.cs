namespace Spoon.NuGet.SecureRemotePassword.Application.Commands.Me.Email.Get;

using Administration.RemoveUserEmail;
using Domain.Entities;
using Domain.Repositories;
using Helpers;

/// <summary>
///     Class ProductCreateQueryHandler. This class cannot be inherited.
/// </summary>
public sealed class MeEmailGetCommandHandler : IRequestHandler<MeEmailGetCommand, Either<MeEmailGetCommandResult>>
{
    private readonly ISecureRemotePasswordRepository _repository;
    private readonly IEncryptionService _encryptionService;


    /// <summary>
    /// </summary>
    /// <param name="repository"></param>
    /// <param name="encryptionService"></param>
    public MeEmailGetCommandHandler(ISecureRemotePasswordRepository repository, IEncryptionService encryptionService)
    {
        this._repository = repository;
        this._encryptionService = encryptionService;
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
    public async Task<Either<MeEmailGetCommandResult>> Handle(
        MeEmailGetCommand request,
        CancellationToken cancellationToken)
    {
        var existingUserEmail = await this._repository.UserEmails.GetAsync(new GetUserEmailSpecification(request.UserId, request.EmailId), cancellationToken);

        if (existingUserEmail == null)
            return EitherHelper<MeEmailGetCommandResult>.EntityNotFound(typeof(UserEmail));

        this._repository.UserEmails.Remove(existingUserEmail);

        await this._repository.SaveChangesAsync(cancellationToken);

        var emailAddress = this._encryptionService.Decrypt(existingUserEmail.EmailAddressEncrypted);
        var result = new MeEmailGetCommandResult
        {
            UserId = existingUserEmail.UserId,
            EmailId = existingUserEmail.EmailId,
            EmailAddress = emailAddress,
            IsPrimary = existingUserEmail.IsPrimary,
            EmailAddressVerifiedAt = existingUserEmail.EmailAddressVerifiedAt,
            CreatedAt = existingUserEmail.CreatedAt,
            UpdatedAt = existingUserEmail.UpdatedAt,
            DeletedAt = existingUserEmail.DeletedAt,
        };
        return new Either<MeEmailGetCommandResult>(result);
    }
}