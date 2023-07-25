namespace Spoon.Demo.Application.V1.Administrator.Contacts.Get.V1.Command;

using Domain.Entities;
using Domain.Repositories;
using NuGet.SecureRemotePassword.Helpers;

/// <summary>
///     Class ProductCreateQueryHandler. This class cannot be inherited.
/// </summary>
public sealed class ContactGetCommandV1Handler : IRequestHandler<ContactGetCommandV1, Either<ContactGetCommandV1Result>>
{
    private readonly IEncryptionService _encryptionService;
    private readonly IContactRepository _repository;

    /// <summary>
    /// </summary>
    /// <param name="repository"></param>
    /// <param name="encryptionService"></param>
    public ContactGetCommandV1Handler(IApplicationRepository repository, IEncryptionService encryptionService)
    {
        this._encryptionService = encryptionService;
        this._repository = repository.Contacts;
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
    public async Task<Either<ContactGetCommandV1Result>> Handle(
        ContactGetCommandV1 request,
        CancellationToken cancellationToken)
    {
        var getSpecification = new DefaultGetSpecification<Contact>(request.ContactId);

        var existing = await this._repository.GetAsync(getSpecification, cancellationToken);

        if (existing == null)
            return EitherHelper<ContactGetCommandV1Result>.EntityNotFound(typeof(ContactGetCommandV1));

        await this._repository.SaveChangesAsync(cancellationToken);

        var result = new ContactGetCommandV1Result
        {
            ContactId = existing.ContactId,
            Email = this._encryptionService.Decrypt(existing.EmailEncrypted),
            Name = this._encryptionService.Decrypt(existing.NameEncrypted),
            Phone = this._encryptionService.Decrypt(existing.PhoneEncrypted),
            Mobil = this._encryptionService.Decrypt(existing.MobilEncrypted),
            CustomerId = existing.CustomerId,
            CreatedAt = existing.CreatedAt,
            ModifiedAt = existing.ModifiedAt,
            DeletedAt = existing.DeletedAt,
        };

        return new Either<ContactGetCommandV1Result>(result);
    }
}