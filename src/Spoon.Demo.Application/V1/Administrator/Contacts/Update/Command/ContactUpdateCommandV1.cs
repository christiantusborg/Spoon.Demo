#pragma warning disable CS8618
namespace Spoon.Demo.Application.V1.Administrator.Contacts.Update.Command;

/// <summary>
///     Class ProductUpdateQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseCommand" />.
/// </summary>
/// <seealso cref="MediatorBaseCommand" />
public sealed class ContactUpdateCommandV1 : MediatorBaseCommand, IHandleableRequest<ContactUpdateCommandV1,
    ContactUpdateCommandV1Handler,
    Either<ContactUpdateCommandV1Result>>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="ContactUpdateCommandV1" /> class.
    /// </summary>
    public ContactUpdateCommandV1()
        : base(typeof(ContactUpdateCommandV1))
    {
    }

    /// <inheritdoc cref="MediatorBaseCommand" />
    public required Guid ContactId { get; init; }

    /// <inheritdoc cref="ContactUpdateCommandV1" />
    public string? Name { get; init; }

    /// <inheritdoc cref="ContactUpdateCommandV1" />
    public string? Description { get; init; }

}