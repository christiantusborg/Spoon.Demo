// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace Spoon.Demo.Application.V1.Administrator.Contacts.Get.V1.Command;

/// <summary>
///     Class ProductCreateQueryResult. This class cannot be inherited.
/// </summary>
public sealed class ContactGetCommandV1Result
{
    /// <inheritdoc cref="ContactGetCommandV1Result" />
    public Guid ContactId { get; set; }
    /// <inheritdoc cref="ContactGetCommandV1Result" />
    public Guid CustomerId { get; set; }
    /// <inheritdoc cref="ContactGetCommandV1Result" />
    public required string Name { get; set; }
    /// <inheritdoc cref="ContactGetCommandV1Result" />
    public required string Email { get; set; }
    /// <inheritdoc cref="ContactGetCommandV1Result" />
    public string? Phone { get; set; }
    /// <inheritdoc cref="ContactGetCommandV1Result" />
    public string? Mobil { get; set; }
    /// <inheritdoc cref="ContactGetCommandV1Result" />
    public required DateTime CreatedAt { get; set; }

    /// <inheritdoc cref="ContactGetCommandV1Result" />
    public required DateTime ModifiedAt { get; set; }

    /// <inheritdoc cref="ContactGetCommandV1Result" />
    public required DateTime? DeletedAt { get; set; }
}