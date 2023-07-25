// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Spoon.Demo.Application.V1.Administrator.Addresses.GetAll.V1.Command;

/// <summary>
///     Class ProductCreateQueryResult. This class cannot be inherited.
/// </summary>
public sealed class AddressGetAllCommandV1Result
{
    /// <inheritdoc cref="AddressGetAllCommandV1Result" />

    public required Guid AddressId { get; set; }

    /// <inheritdoc cref="AddressGetAllCommandV1Result" />
    public Guid CustomerId { get; set; }
    /// <inheritdoc cref="AddressGetAllCommandV1Result" />
    public required string AddressOne { get; set; }
    /// <inheritdoc cref="AddressGetAllCommandV1Result" />
    public string? AddressTwo { get; set; }
    /// <inheritdoc cref="AddressGetAllCommandV1Result" />
    public required string Zip { get; set; }
    /// <inheritdoc cref="AddressGetAllCommandV1Result" />
    public required string City { get; set; }
    /// <inheritdoc cref="AddressGetAllCommandV1Result" />
    public required string Country { get; set; }
    /// <inheritdoc cref="AddressGetAllCommandV1Result" />
    public required int AddressTypeId { get; set; }

    /// <inheritdoc cref="AddressGetAllCommandV1Result" />
    public required DateTime CreatedAt { get; set; }

    /// <inheritdoc cref="AddressGetAllCommandV1Result" />
    public required DateTime ModifiedAt { get; set; }

    /// <inheritdoc cref="AddressGetAllCommandV1Result" />
    public required DateTime? DeletedAt { get; set; }
}