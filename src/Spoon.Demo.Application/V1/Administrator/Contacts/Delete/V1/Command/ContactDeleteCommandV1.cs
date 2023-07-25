namespace Spoon.Demo.Application.V1.Administrator.Contacts.Delete.V1.Command;

/// <summary>
///     Class ProductDeleteQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseCommand" />.
/// </summary>
/// <seealso cref="MediatorBaseCommand" />
public sealed class ContactDeleteCommandV1 : MediatorBaseCommand, IHandleableRequest<ContactDeleteCommandV1,
    ContactDeleteCommandV1Handler,
    Either<ContactDeleteCommandV1Result>>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="ContactDeleteCommandV1" /> class.
    /// </summary>
    public ContactDeleteCommandV1()
        : base(typeof(ContactDeleteCommandV1))
    {
    }

    /// <summary>
    ///     Gets or sets the product identifier.
    /// </summary>
    /// <value>The product identifier.</value>
    public required Guid ContactId { get; set; }
}