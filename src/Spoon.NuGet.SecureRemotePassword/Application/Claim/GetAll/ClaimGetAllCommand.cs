namespace Spoon.NuGet.SecureRemotePassword.Application.Claim.GetAll;

using Core.Application;
using EitherCore;
using Mediator;
using Mediator.Interfaces;

/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseQuery" />.
/// </summary>
/// <seealso cref="MediatorBaseQuery" />
public sealed class ClaimGetAllCommand : MediatorBaseCommandSearch, IHandleableRequest<ClaimGetAllCommand,
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