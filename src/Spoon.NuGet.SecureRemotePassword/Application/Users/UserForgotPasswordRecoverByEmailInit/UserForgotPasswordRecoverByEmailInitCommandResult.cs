// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Spoon.NuGet.SecureRemotePassword.Application.Users.UserForgotPasswordRecoverByEmailInit;

/// <summary>
///     Class ProductCreateQueryResult. This class cannot be inherited.
/// </summary>
public sealed class UserForgotPasswordRecoverByEmailInitCommandResult
{
    /// <inheritdoc cref="UserForgotPasswordRecoverByEmailInitCommandResult" />
    public Guid EmailId { get; set; }
    /// <inheritdoc cref="UserForgotPasswordRecoverByEmailInitCommandResult" />
    public required string Email { get; set; }
    /// <inheritdoc cref="UserForgotPasswordRecoverByEmailInitCommandResult" />
    public required string RecoveryString { get; set; }
}