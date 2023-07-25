#pragma warning disable CS8618
namespace Spoon.Demo.Application.V1.Administrator.Addresses.Create.V1.Command;

/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseCommand" />.
/// </summary>
/// <seealso cref="MediatorBaseCommand" />
public sealed class AddressCreateCommandV1 : MediatorBaseCommand, IHandleableRequest<AddressCreateCommandV1, AddressCreateCommandV1Handler, Either<AddressCreateCommandV1Result>>
{
    //Role->Manager.Add(AddressCreateCommandV1)
    // Property {
    // Id
    //  Name*
    //  Value
    //  Required*
    //  Length*
    //  Type*
    //  Roels* = {
    //    "Manager" : Read
    // }
    // }
    //
    //
    
    /// <summary>
    ///     Initializes a new instance of the <see cref="AddressCreateCommandV1" /> class.
    ///     Handled by <see cref="AddressCreateCommandV1Handler" /> class.
    /// </summary>
    public AddressCreateCommandV1() : base(typeof(AddressCreateCommandV1))
    {
    }

    /// <inheritdoc cref="AddressCreateCommandV1" />
    public Guid CustomerId { get; set; }
    /// <inheritdoc cref="AddressCreateCommandV1" />
    public required string AddressOne { get; set; }
    /// <inheritdoc cref="AddressCreateCommandV1" />
    public string? AddressTwo { get; set; }
    /// <inheritdoc cref="AddressCreateCommandV1" />
    public required string Zip { get; set; }
    /// <inheritdoc cref="AddressCreateCommandV1" />
    public required string City { get; set; }
    /// <inheritdoc cref="AddressCreateCommandV1" />
    public required string Country { get; set; }
    /// <inheritdoc cref="AddressCreateCommandV1" />
    public required int AddressTypeId { get; set; }
}