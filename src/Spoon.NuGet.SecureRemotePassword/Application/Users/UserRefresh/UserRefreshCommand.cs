namespace Spoon.NuGet.SecureRemotePassword.Application.Users.UserRefresh;

using Spoon.NuGet.EitherCore;
using Spoon.NuGet.Mediator;
using Spoon.NuGet.Mediator.Interfaces;

/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseQuery" />.
/// </summary>
/// <seealso cref="MediatorBaseQuery" />
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
    
    public required string RefreshToken { get; set; } 
}