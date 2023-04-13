// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Spoon.NuGet.SecureRemotePassword.Application.Administration.GetAllUser;

/// <summary>
///     Class ProductCreateQueryResult. This class cannot be inherited.
/// </summary>
public sealed class AdministrationGetAllUserCommandResult
{
    /// <inheritdoc cref="AdministrationGetAllUserCommandResult" />
    public Guid UserId { get; set; }

    /// <inheritdoc cref="AdministrationGetAllUserCommandResult" />
    public DateTime? DisabledAt { get; set; }

    /// <inheritdoc cref="AdministrationGetAllUserCommandResult" />
    public DateTime? LockoutEnd { get; set; }

    /// <inheritdoc cref="AdministrationGetAllUserCommandResult" />
    public int LockoutCount { get; set; }

    /// <inheritdoc cref="AdministrationGetAllUserCommandResult" />
    public DateTime? MustChangePassword { get; set; }

    /// <inheritdoc cref="AdministrationGetAllUserCommandResult" />
    public DateTime? LastLogin { get; set; }

    /// <inheritdoc cref="AdministrationGetAllUserCommandResult" />
    public required DateTime CreatedAt { get; set; }

    /// <inheritdoc cref="AdministrationGetAllUserCommandResult" />
    public required DateTime UpdatedAt { get; set; }

    /// <inheritdoc cref="AdministrationGetAllUserCommandResult" />
    public DateTime? DeletedAt { get; set; }
}