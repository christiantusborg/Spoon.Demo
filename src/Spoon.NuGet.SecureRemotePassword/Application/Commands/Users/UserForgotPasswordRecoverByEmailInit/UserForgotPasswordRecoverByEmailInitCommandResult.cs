// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Spoon.NuGet.SecureRemotePassword.Application.Commands.Users.UserForgotPasswordRecoverByEmailInit;

/// <summary>
///     Class ProductCreateQueryResult. This class cannot be inherited.
/// </summary>
public sealed class UserForgotPasswordRecoverByEmailInitCommandResult
{
    /// <inheritdoc cref="UserForgotPasswordRecoverByEmailInitCommandResult" />
    public Guid UserId { get; set; }

    /// <inheritdoc cref="UserForgotPasswordRecoverByEmailInitCommandResult" />
    public required string Email { get; set; }

    /// <inheritdoc cref="UserForgotPasswordRecoverByEmailInitCommandResult" />
    public required string RecoveryString { get; set; }
}