namespace Spoon.NuGet.SecureRemotePassword.Application.Users.UserLogout;

using Spoon.NuGet.EitherCore;
using Spoon.NuGet.Mediator;
using Spoon.NuGet.Mediator.Interfaces;

/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseQuery" />.
/// </summary>
/// <seealso cref="MediatorBaseQuery" />
public sealed class UserLogoutCommand : MediatorBaseCommand, IHandleableRequest<UserLogoutCommand,
    UserLogoutCommandHandler, Either<UserLogoutCommandResult>>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="UserLogoutCommand" /> class.
    /// </summary>
    public UserLogoutCommand()
        : base(typeof(UserLogoutCommand))
    {
    
    }
    
    public required Guid UserId { get; set; }
    
    public required Guid Session{ get; set; }
}