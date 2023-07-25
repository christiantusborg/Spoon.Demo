namespace Spoon.Demo.Application.V1.Administrator.Contacts.Delete.V1.Command;

using Domain.Entities;
using Domain.Repositories;

/// <summary>
///     Class ProductDeleteQueryHandler. This class cannot be inherited.
/// </summary>
public sealed class ContactDeleteCommandV1Handler : IRequestHandler<ContactDeleteCommandV1, Either<ContactDeleteCommandV1Result>>
{
    private readonly IContactRepository _repository;
    private readonly IMockbleDateTime _mockbleDateTime;


    /// <summary>
    /// </summary>
    /// <param name="repository"></param>
    /// <param name="mockbleDateTime"></param>
    public ContactDeleteCommandV1Handler(IApplicationRepository repository, IMockbleDateTime mockbleDateTime)
    {
        this._repository = repository.Contacts;
        this._mockbleDateTime = mockbleDateTime;
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
    public async Task<Either<ContactDeleteCommandV1Result>> Handle(
        ContactDeleteCommandV1 request,
        CancellationToken cancellationToken)
    {
        var getSpecification = new DefaultGetSpecification<Contact>(request.ContactId);

        var exiting = await this._repository.GetAsync(getSpecification, cancellationToken);

        if (exiting is null)
        {
            return EitherHelper<ContactDeleteCommandV1Result>.EntityNotFound(typeof(ContactDeleteCommandV1));
        }

        exiting.DeletedAt = this._mockbleDateTime.UtcNow;

        await this._repository.SaveChangesAsync(cancellationToken);

        return new Either<ContactDeleteCommandV1Result>(new ContactDeleteCommandV1Result());
    }
}