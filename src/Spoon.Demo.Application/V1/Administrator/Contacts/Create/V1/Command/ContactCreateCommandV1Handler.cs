namespace Spoon.Demo.Application.V1.Administrator.Contacts.Create.V1.Command;

using Domain.Entities;
using Domain.Repositories;
using NuGet.SecureRemotePassword.Helpers;

/// <summary>
///     Class ProductCreateQueryHandler. This class cannot be inherited.
/// </summary>
public sealed class ContactCreateCommandV1Handler : IRequestHandler<ContactCreateCommandV1, Either<ContactCreateCommandV1Result>>
{
    private readonly IContactRepository _repository;
    private readonly IMockbleGuidGenerator _mockbleGuidGenerator;
    private readonly IMockbleDateTime _mockbleDateTime;
    private readonly IEncryptionService _encryptionService;

    /// <summary>
    ///     Initializes a new instance of the
    ///     <see>
    ///         <cref>ContactCreateCommandV1Handler</cref>
    ///     </see>
    ///     class.
    /// </summary>
    /// <param name="repository"></param>
    /// <param name="mockbleGuidGenerator"></param>
    /// <param name="mockbleDateTime"></param>
    /// <param name="encryptionService"></param>
    public ContactCreateCommandV1Handler(IApplicationRepository repository, IMockbleGuidGenerator mockbleGuidGenerator, IMockbleDateTime mockbleDateTime, IEncryptionService encryptionService)
    {
        this._repository = repository.Contacts;
        this._mockbleGuidGenerator = mockbleGuidGenerator;
        this._mockbleDateTime = mockbleDateTime;
        this._encryptionService = encryptionService;
    }

    /// <summary>
    ///     Handles the specified request.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<Either<ContactCreateCommandV1Result>> Handle(
        ContactCreateCommandV1 request,
        CancellationToken cancellationToken)
    {
        var getByNameSpecification = new GetByNameSpecification<Contact>(request.Name);

        var existing = await this._repository.GetAsync(getByNameSpecification, cancellationToken);

        if (existing is not null)
            return EitherHelper<ContactCreateCommandV1Result>.EntityAlreadyExists(typeof(ContactCreateCommandV1));

        var newId = this._mockbleGuidGenerator.NewId();

        var next = new Contact
        {
            ContactId = newId,
            CustomerId = request.CustomerId,
            EmailEncrypted = this._encryptionService.Encrypt(request.Email),
            MobilEncrypted = this._encryptionService.Encrypt(request.Mobil),
            NameEncrypted = this._encryptionService.Encrypt(request.Name),
            PhoneEncrypted = this._encryptionService.Encrypt(request.Phone),
            NewsLetterSignupDate = request.NewsLetterSignupDate ? this._mockbleDateTime.UtcNow : null,
            CreatedAt = this._mockbleDateTime.UtcNow,
            ModifiedAt = this._mockbleDateTime.UtcNow,
            DeletedAt = null,
        };

        this._repository.Add(next);

        await this._repository.SaveChangesAsync(cancellationToken);

        var result = new ContactCreateCommandV1Result
        {
            ContactId = next.ContactId,
        };

        return new Either<ContactCreateCommandV1Result>(result);
    }
}