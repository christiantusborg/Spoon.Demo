namespace Spoon.Demo.Application.V1.Addresses.DeleteSoft;

using Spoon.NuGet.EitherCore;
using Spoon.NuGet.Mediator;
using Spoon.NuGet.Mediator.Interfaces;

/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseQuery" />.
/// </summary>
/// <seealso cref="MediatorBaseQuery" />
public sealed class AddressesDeleteUserSoftCommand : MediatorBaseCommand, IHandleableRequest<AddressesDeleteUserSoftCommand,
    AddressesDeleteUserSoftCommandHandler, Either<AddressesDeleteUserSoftCommandResult>>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="AddressesDeleteUserSoftCommand" /> class.
    /// </summary>
    public AddressesDeleteUserSoftCommand()
        : base(typeof(AddressesDeleteUserSoftCommand))
    {
    }

    /// <inheritdoc cref="AddressesDeleteUserSoftCommand" />
    public required Guid CustomerId { get; init; }

    public required Guid AddressId { get; set; }
}
