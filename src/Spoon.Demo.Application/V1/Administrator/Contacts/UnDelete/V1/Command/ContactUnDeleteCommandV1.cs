namespace Spoon.Demo.Application.V1.Administrator.Contacts.UnDelete.V1.Command;

/// <summary>
///     Class ProductDeleteQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseCommand" />.
/// </summary>
/// <seealso cref="MediatorBaseCommand" />
public sealed class ContactUnDeleteCommandV1 : MediatorBaseCommand, IHandleableRequest<ContactUnDeleteCommandV1,
    ContactUnDeleteCommandV1Handler,
    Either<ContactUnDeleteCommandV1Result>>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="ContactUnDeleteCommandV1" /> class.
    /// </summary>
    public ContactUnDeleteCommandV1()
        : base(typeof(ContactUnDeleteCommandV1))
    {
    }

    /// <inheritdoc cref="MediatorBaseCommand" />
    public required Guid ContactId { get; set; }
}