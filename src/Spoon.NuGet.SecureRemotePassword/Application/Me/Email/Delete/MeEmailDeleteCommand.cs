namespace Spoon.NuGet.SecureRemotePassword.Application.Me.Email.Delete;

using Spoon.NuGet.EitherCore;
using Spoon.NuGet.Mediator;
using Spoon.NuGet.Mediator.Interfaces;

/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseQuery" />.
/// </summary>
/// <seealso cref="MediatorBaseQuery" />
public sealed class MeEmailDeleteCommand : MediatorBaseCommand, IHandleableRequest<MeEmailDeleteCommand,
    MeEmailDeleteCommandHandler, Either<MeEmailDeleteCommandResult>>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="MeEmailDeleteCommand" /> class.
    /// </summary>
    public MeEmailDeleteCommand()
        : base(typeof(MeEmailDeleteCommand))
    {
    
    }
    
    public Guid UserId {internal get; set; }
    public required Guid EmailId { get; init; }

}