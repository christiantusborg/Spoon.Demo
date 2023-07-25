namespace Spoon.Demo.Application.V1.Administrator.Contacts.UnDelete.V1.Command;

using Domain.Entities;
using Domain.Repositories;

/// <summary>
///     Class ProductDeleteQueryHandler. This class cannot be inherited.
/// </summary>
public sealed class ContactUnDeleteCommandV1Handler : IRequestHandler<ContactUnDeleteCommandV1, Either<ContactUnDeleteCommandV1Result>>
{
    private readonly IContactRepository _repository;

    /// <summary>
    /// </summary>
    /// <param name="repository"></param>
    public ContactUnDeleteCommandV1Handler(IApplicationRepository repository)
    {
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
    /// <returns>Task&lt;Either&lt;ProductDeleteQueryResult&gt;&gt;.</returns>
    public async Task<Either<ContactUnDeleteCommandV1Result>> Handle(
        ContactUnDeleteCommandV1 request,
        CancellationToken cancellationToken)
    {
        var getSpecification = new DefaultGetSpecification<Contact>(request.ContactId);

        var existing = await this._repository.GetAsync(getSpecification, cancellationToken);

        if (existing is null)
        {
            return EitherHelper<ContactUnDeleteCommandV1Result>.EntityNotFound(typeof(ContactUnDeleteCommandV1));
        }

        existing.DeletedAt = null;

        await this._repository.SaveChangesAsync(cancellationToken);

        return new Either<ContactUnDeleteCommandV1Result>(new ContactUnDeleteCommandV1Result());
    }
}