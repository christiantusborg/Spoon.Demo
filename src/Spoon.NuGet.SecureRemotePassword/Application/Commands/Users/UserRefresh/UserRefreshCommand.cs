// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace Spoon.NuGet.SecureRemotePassword.Application.Commands.Users.UserRefresh;

using Core.Application;
using Core.Application.Interfaces;

/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseCommand" />.
/// </summary>
/// <seealso cref="MediatorBaseCommand" />
public sealed class UserRefreshCommand : MediatorBaseCommand, IHandleableRequest<UserRefreshCommand,
    UserRefreshCommandHandler, Either<UserRefreshCommandResult>>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="UserRefreshCommand" /> class.
    /// </summary>
    public UserRefreshCommand()
        : base(typeof(UserRefreshCommand))
    {
    }

    /// <inheritdoc cref="UserRefreshCommand" />
    public required string RefreshToken { get; set; }

    /// <inheritdoc cref="UserRefreshCommand" />
    public required Guid UserId { get; set; }

    /// <inheritdoc cref="UserRefreshCommand" />
    public required long Iat { get; set; }

    /// <inheritdoc cref="UserRefreshCommand" />
    public required string RefreshTokenVerifier { get; set; }

    /// <inheritdoc cref="UserRefreshCommand" />
    public required Guid SessionId { get; set; }
}