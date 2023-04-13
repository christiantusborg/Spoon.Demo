// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Spoon.NuGet.SecureRemotePassword.Application.Roles.GetAll;

/// <summary>
///     Class ProductCreateQueryResult. This class cannot be inherited.
/// </summary>
public sealed class RoleGetAllCommandResult
{
    /// <inheritdoc cref="RoleGetAllCommandResult" />
    public Guid RoleId { get; init; }

    /// <inheritdoc cref="RoleGetAllCommandResult" />
    public string? Name { get; init; }

    /// <inheritdoc cref="RoleGetAllCommandResult" />
    public DateTime CreatedAt { get; init; }

    /// <inheritdoc cref="RoleGetAllCommandResult" />
    public DateTime UpdatedAt { get; init; }

    /// <inheritdoc cref="RoleGetAllCommandResult" />
    public DateTime? DeletedAt { get; init; }
}