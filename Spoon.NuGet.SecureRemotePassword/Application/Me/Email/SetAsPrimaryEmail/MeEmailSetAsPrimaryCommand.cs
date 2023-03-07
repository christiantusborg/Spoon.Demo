namespace Spoon.NuGet.SecureRemotePassword.Application.Me.Email.SetAsPrimaryEmail;

using Spoon.NuGet.EitherCore;
using Spoon.NuGet.Mediator;
using Spoon.NuGet.Mediator.Interfaces;

/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseQuery" />.
/// </summary>
/// <seealso cref="MediatorBaseQuery" />
public sealed class MeEmailSetAsPrimaryCommand : MediatorBaseCommand, IHandleableRequest<MeEmailSetAsPrimaryCommand,
    MeEmailSetAsPrimaryCommandHandler, Either<MeEmailSetAsPrimaryCommandResult>>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="MeEmailSetAsPrimaryCommand" /> class.
    /// </summary>
    public MeEmailSetAsPrimaryCommand()
        : base(typeof(MeEmailSetAsPrimaryCommand))
    {
    
    }
    
    public Guid UserId {internal get; set; }
    public required Guid EmailId { get; init; }

}