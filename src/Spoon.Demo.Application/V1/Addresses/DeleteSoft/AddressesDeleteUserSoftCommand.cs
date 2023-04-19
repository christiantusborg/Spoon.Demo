namespace Spoon.Demo.Application.V1.Addresses.DeleteSoft;

using NuGet.Core.Application;
using NuGet.Core.Application.Interfaces;
using NuGet.Core.EitherCore;

/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseCommand" />.
/// </summary>
/// <seealso cref="MediatorBaseCommand" />
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