namespace Spoon.NuGet.SecureRemotePassword.Application.User.UserRegister;

using Spoon.NuGet.EitherCore;
using Spoon.NuGet.Mediator;
using Spoon.NuGet.Mediator.Interfaces;

/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseQuery" />.
/// </summary>
/// <seealso cref="MediatorBaseQuery" />
public sealed class UserRegisterCommand : MediatorBaseCommand, IHandleableRequest<UserRegisterCommand,
    UserRegisterCommandHandler, Either<UserRegisterCommandResult>>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="UserRegisterCommand" /> class.
    /// </summary>
    public UserRegisterCommand()
        : base(typeof(UserRegisterCommand))
    {
    
    }
    
    public Guid UserId {internal get; set; }
    public string Email { internal get; set; }
    public string Verifier { get; set; }
    public string Salt { get; set; }
}