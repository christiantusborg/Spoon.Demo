namespace Spoon.NuGet.SecureRemotePassword.Application.Commands.Claim.GetAll;

using Core.Application.Interfaces;
using Spoon.NuGet.Core.Application;

/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseCommandSearch" />.
/// </summary>
/// <seealso cref="MediatorBaseCommandSearch" />
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