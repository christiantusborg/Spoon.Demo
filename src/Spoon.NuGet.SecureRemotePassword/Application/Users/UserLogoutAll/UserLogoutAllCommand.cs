namespace Spoon.NuGet.SecureRemotePassword.Application.Users.UserLogoutAll;

using Spoon.NuGet.EitherCore;
using Spoon.NuGet.Mediator;
using Spoon.NuGet.Mediator.Interfaces;

/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseQuery" />.
/// </summary>
/// <seealso cref="MediatorBaseQuery" />
public sealed class UserLogoutAllCommand : MediatorBaseCommand, IHandleableRequest<UserLogoutAllCommand,
    UserLogoutAllCommandHandler, Either<UserLogoutAllCommandResult>>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="UserLogoutAllCommand" /> class.
    /// </summary>
    public UserLogoutAllCommand()
        : base(typeof(UserLogoutAllCommand))
    {
    
    }
    
    public required Guid UserId { get; set; }
}