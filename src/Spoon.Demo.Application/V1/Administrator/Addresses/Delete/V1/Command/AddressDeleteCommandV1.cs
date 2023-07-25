namespace Spoon.Demo.Application.V1.Administrator.Addresses.Delete.V1.Command;

/// <summary>
///     Class ProductDeleteQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseCommand" />.
/// </summary>
/// <seealso cref="MediatorBaseCommand" />
public sealed class AddressDeleteCommandV1 : MediatorBaseCommand, IHandleableRequest<AddressDeleteCommandV1,
    AddressDeleteCommandV1Handler,
    Either<AddressDeleteCommandV1Result>>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="AddressDeleteCommandV1" /> class.
    /// </summary>
    public AddressDeleteCommandV1()
        : base(typeof(AddressDeleteCommandV1))
    {
    }

    /// <summary>
    ///     Gets or sets the product identifier.
    /// </summary>
    /// <value>The product identifier.</value>
    public required Guid AddressId { get; set; }
}