// ReSharper disable ClassNeverInstantiated.Global

namespace Spoon.Demo.Application.V1.Administrator.Contacts.GetAll.V1.Command;

using Domain.Entities;
using Domain.Repositories;
using NuGet.SecureRemotePassword.Helpers;

/// <summary>
///     Class ProductCreateQueryHandler. This class cannot be inherited.
/// </summary>
public sealed class ContactGetAllCommandV1Handler : IRequestHandler<ContactGetAllCommandV1, Either<BaseSearchCommandResult<ContactGetAllCommandV1Result>>>
{
    private readonly IEncryptionService _encryptionService;
    private readonly IContactRepository _repository;

    /// <summary>
    /// </summary>
    /// <param name="repository"></param>
    /// <param name="encryptionService"></param>
    public ContactGetAllCommandV1Handler(IApplicationRepository repository, IEncryptionService encryptionService)
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
    public async Task<Either<BaseSearchCommandResult<ContactGetAllCommandV1Result>>> Handle(
        ContactGetAllCommandV1 request,
        CancellationToken cancellationToken)
    {
        var getAllSpecification = new DefaultSearchSpecification<Contact>(request.Filters, request.SortField, request.Skip, request.Take, request.IncludeDeleted);
        var existing = await this._repository.SearchAsync(getAllSpecification, cancellationToken);

        if (existing.Count == 0)
            return new Either<BaseSearchCommandResult<ContactGetAllCommandV1Result>>(new BaseSearchCommandResult<ContactGetAllCommandV1Result>());

        var total = await this._repository.CountAsync(getAllSpecification, cancellationToken);

        var result = new BaseSearchCommandResult<ContactGetAllCommandV1Result>
        {
            Items = existing.Select(x => new ContactGetAllCommandV1Result
            {
                ContactId = x.ContactId,
                Email = this._encryptionService.Decrypt(x.EmailEncrypted),
                Name = this._encryptionService.Decrypt(x.NameEncrypted),
                Phone = this._encryptionService.Decrypt(x.PhoneEncrypted),
                Mobil = this._encryptionService.Decrypt(x.MobilEncrypted),
                CustomerId = x.CustomerId,
                CreatedAt = x.CreatedAt,
                ModifiedAt = x.ModifiedAt,
                DeletedAt = x.DeletedAt,
            }).ToList(),
            Total = total,
        };

        return new Either<BaseSearchCommandResult<ContactGetAllCommandV1Result>>(result);
    }
}