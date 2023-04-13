namespace Spoon.NuGet.SecureRemotePassword.Application.Me.Email.GetAll;

using Domain.Entities;
using Domain.Repositories;
using EitherCore;
using EitherCore.Helpers;
using Helpers;
using MediatR;

/// <summary>
///     Class ProductCreateQueryHandler. This class cannot be inherited.
/// </summary>
public sealed class MeEmailGetAllCommandHandler : IRequestHandler<MeEmailGetAllCommand, Either<BaseSearchCommandResultExtendedWithUserId<MeEmailGetAllCommandResult>>>
{
    private readonly ISecureRemotePasswordRepository _repository;
    private readonly IEncryptionService _encryptionService;


    /// <summary>
    /// </summary>
    /// <param name="repository"></param>
    /// <param name="encryptionService"></param>
    public MeEmailGetAllCommandHandler(ISecureRemotePasswordRepository repository, IEncryptionService encryptionService)
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
    public async Task<Either<BaseSearchCommandResultExtendedWithUserId<MeEmailGetAllCommandResult>>> Handle(
        MeEmailGetAllCommand request,
        CancellationToken cancellationToken)
    {
        var existingUserEmail = await this._repository.UserEmails.SearchAsync(new MeEmailGetAllCommandSpecification(request.UserId), cancellationToken);

        if (existingUserEmail.Count == 0)
            return EitherHelper<BaseSearchCommandResultExtendedWithUserId<MeEmailGetAllCommandResult>>.EntityNotFound(typeof(UserEmail));


        var listOfEmails = this.GetEmailsDecrypted(existingUserEmail);
        var total = await this._repository.UserEmails.CountAsync(new MeEmailGetAllCommandSpecification(request.UserId), cancellationToken);
        var result = new BaseSearchCommandResultExtendedWithUserId<MeEmailGetAllCommandResult>
        {
            Items = listOfEmails,
            UserId = request.UserId,
            Total = total,
        };

        return new Either<BaseSearchCommandResultExtendedWithUserId<MeEmailGetAllCommandResult>>(result);
    }

    private List<MeEmailGetAllCommandResult> GetEmailsDecrypted(List<UserEmail> userEmail)
    {
        var result = userEmail.Select(email => new MeEmailGetAllCommandResult
            {
                EmailId = email.EmailId,
                Email = this._encryptionService.Decrypt(email.EmailAddressEncrypted),
                IsPrimary = email.IsPrimary == 1,
            })
            .ToList();

        return result;
    }
}