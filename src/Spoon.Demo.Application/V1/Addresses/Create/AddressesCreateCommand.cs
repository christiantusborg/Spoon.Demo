
namespace Spoon.Demo.Application.V1.Addresses.Create;

using Spoon.NuGet.EitherCore;
using Spoon.NuGet.Mediator;
using Spoon.NuGet.Mediator.Interfaces;


//AddressesCreate
/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseQuery" />.
/// </summary>
/// <seealso cref="MediatorBaseQuery" />
public sealed class AddressesCreateCommand : MediatorBaseCommand, IHandleableRequest<AddressesCreateCommand,
    AddressesCreateCommandHandler, Either<AddressesCreateCommandResult>>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="AddressesCreateCommand" /> class.
    /// </summary>
    public AddressesCreateCommand()
        : base(typeof(AddressesCreateCommand))
    {
    }

    /// <inheritdoc cref="AddressesCreateCommand" />
    public required string AddressOne { get; init; }
    /// <inheritdoc cref="AddressesCreateCommand" />
    public required string AddressTwo { get; init; }
    /// <inheritdoc cref="AddressesCreateCommand" />
    public required string Zip { get; init; }
    /// <inheritdoc cref="AddressesCreateCommand" />
    public required string City { get; init; }
    /// <inheritdoc cref="AddressesCreateCommand" />
    public required string Country { get; init; }

    public int AddressTypeId { get; init; }
    public Guid CustomerId { get; init; }
}