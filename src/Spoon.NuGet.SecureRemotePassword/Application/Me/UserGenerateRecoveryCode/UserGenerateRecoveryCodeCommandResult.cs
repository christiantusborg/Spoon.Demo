// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Spoon.NuGet.SecureRemotePassword.Application.Me.UserGenerateRecoveryCode;

/// <summary>
///     Class ProductCreateQueryResult. This class cannot be inherited.
/// </summary>
public sealed class UserGenerateRecoveryCodeCommandResult
{
    /// <inheritdoc cref="UserGenerateRecoveryCodeCommandResult" />
    //[System.ComponentModel.DataAnnotations.StringLength(10, MinimumLength = 10, ErrorMessage = "Recovery code must be 10 characters long")]
    public required string RecoveryCode { get; init; }
}