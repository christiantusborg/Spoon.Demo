namespace Spoon.Demo.Application.V1.Administrator.Addresses.UnDelete.V1.Command;

/// <summary>
///     Class ProductDeleteQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseCommand" />.
/// </summary>
/// <seealso cref="MediatorBaseCommand" />
public sealed class AddressUnDeleteCommandV1 : MediatorBaseCommand, IHandleableRequest<AddressUnDeleteCommandV1,
    AddressUnDeleteCommandV1Handler,
    Either<AddressUnDeleteCommandV1Result>>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="AddressUnDeleteCommandV1" /> class.
    /// </summary>
    public AddressUnDeleteCommandV1()
        : base(typeof(AddressUnDeleteCommandV1))
    {
    }

    /// <inheritdoc cref="MediatorBaseCommand" />
    public required Guid AddressId { get; set; }
}