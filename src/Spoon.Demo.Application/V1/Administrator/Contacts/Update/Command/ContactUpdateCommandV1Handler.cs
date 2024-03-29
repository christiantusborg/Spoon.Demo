namespace Spoon.Demo.Application.V1.Administrator.Contacts.Update.Command;

using Domain.Entities;
using Domain.Repositories;

/// <summary>
///     Class ProductUpdateQueryHandler. This class cannot be inherited.
/// </summary>
public sealed class ContactUpdateCommandV1Handler : IRequestHandler<ContactUpdateCommandV1, Either<ContactUpdateCommandV1Result>>
{
    private readonly IColorRepository _repository;
    private readonly IMockbleDateTime _mockbleDateTime;

    /// <summary>
    /// </summary>
    /// <param name="repository"></param>
    /// <param name="mockbleDateTime"></param>
    public ContactUpdateCommandV1Handler(IApplicationRepository repository, IMockbleDateTime mockbleDateTime)
    {
        this._repository = repository.Colors;
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
    /// <returns>Task&lt;Either&lt;ProductUpdateQueryResult&gt;&gt;.</returns>
    public async Task<Either<ContactUpdateCommandV1Result>> Handle(
        ContactUpdateCommandV1 request,
        CancellationToken cancellationToken)
    {
        var getSpecification = new DefaultGetSpecification<Color>(request.ContactId);

        var existing = await this._repository.GetAsync(getSpecification, cancellationToken);

        if (existing is null)
            return EitherHelper<ContactUpdateCommandV1Result>.EntityNotFound(typeof(ContactUpdateCommandV1));

        existing.Name = request.Name ?? existing.Name;
        existing.Description = request.Description ?? existing.Description;
        existing.ModifiedAt = this._mockbleDateTime.UtcNow;

        await this._repository.SaveChangesAsync(cancellationToken);

        return new Either<ContactUpdateCommandV1Result>(new ContactUpdateCommandV1Result());
    }
}