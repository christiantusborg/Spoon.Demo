#pragma warning disable CS8618
namespace Spoon.Demo.Application.V1.Administrator.Addresses.Update.Command;

/// <summary>
///     Class ProductUpdateQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseCommand" />.
/// </summary>
/// <seealso cref="MediatorBaseCommand" />
public sealed class AddressUpdateCommandV1 : MediatorBaseCommand, IHandleableRequest<AddressUpdateCommandV1,
    AddressUpdateCommandV1Handler,
    Either<AddressUpdateCommandV1Result>>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="AddressUpdateCommandV1" /> class.
    /// </summary>
    public AddressUpdateCommandV1()
        : base(typeof(AddressUpdateCommandV1))
    {
    }

    /// <inheritdoc cref="MediatorBaseCommand" />
    public required Guid AddressId { get; init; }

    /// <inheritdoc cref="MediatorBaseCommand" />
    public Guid? CustomerId { get; set; }
    /// <inheritdoc cref="MediatorBaseCommand" />
    public string? AddressOne { get; set; }
    /// <inheritdoc cref="MediatorBaseCommand" />
    public string? AddressTwo { get; set; }
    /// <inheritdoc cref="MediatorBaseCommand" />
    public string? Zip { get; set; }
    /// <inheritdoc cref="MediatorBaseCommand" />
    public string? City { get; set; }
    /// <inheritdoc cref="MediatorBaseCommand" />
    public string? Country { get; set; }
    /// <inheritdoc cref="MediatorBaseCommand" />
    public int? AddressTypeId { get; set; }
}