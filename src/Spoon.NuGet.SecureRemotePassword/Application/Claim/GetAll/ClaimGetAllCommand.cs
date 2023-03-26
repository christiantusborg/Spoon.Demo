namespace Spoon.NuGet.SecureRemotePassword.Application.Claim.GetAll;

using Spoon.NuGet.EitherCore;
using Spoon.NuGet.Mediator;
using Spoon.NuGet.Mediator.Interfaces;

/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseQuery" />.
/// </summary>
/// <seealso cref="MediatorBaseQuery" />
public sealed class ClaimGetAllCommand : MediatorBaseCommand, IHandleableRequest<ClaimGetAllCommand,
    ClaimGetAllCommandHandler, Either<ClaimGetAllCommandUserCommandResult>>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="ClaimGetAllCommand" /> class.
    /// </summary>
    public ClaimGetAllCommand()
        : base(typeof(ClaimGetAllCommand))
    {
    }
}