// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Spoon.Demo.Application.V1.Administrator.Contacts.GetAll.V1.Command;

/// <summary>
///     Class ProductCreateQueryResult. This class cannot be inherited.
/// </summary>
public sealed class ContactGetAllCommandV1Result
{
    /// <inheritdoc cref="ContactGetAllCommandV1Result" />
    public Guid ContactId { get; set; }
    /// <inheritdoc cref="ContactGetAllCommandV1Result" />
    public Guid CustomerId { get; set; }
    /// <inheritdoc cref="ContactGetAllCommandV1Result" />
    public required string Name { get; set; }
    /// <inheritdoc cref="ContactGetAllCommandV1Result" />
    public required string Email { get; set; }
    /// <inheritdoc cref="ContactGetAllCommandV1Result" />
    public string? Phone { get; set; }
    /// <inheritdoc cref="ContactGetAllCommandV1Result" />
    public string? Mobil { get; set; }
    /// <inheritdoc cref="ContactGetAllCommandV1Result" />
    public required DateTime CreatedAt { get; set; }

    /// <inheritdoc cref="ContactGetAllCommandV1Result" />
    public required DateTime ModifiedAt { get; set; }

    /// <inheritdoc cref="ContactGetAllCommandV1Result" />
    public required DateTime? DeletedAt { get; set; }
}