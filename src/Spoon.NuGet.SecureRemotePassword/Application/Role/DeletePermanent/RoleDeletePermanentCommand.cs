
namespace Spoon.NuGet.SecureRemotePassword.Application.Role.DeletePermanent;

using Spoon.NuGet.EitherCore;
using Spoon.NuGet.Mediator;
using Spoon.NuGet.Mediator.Interfaces;

/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseQuery" />.
/// </summary>
/// <seealso cref="MediatorBaseQuery" />
public sealed class RoleDeletePermanentCommand : MediatorBaseCommand, IHandleableRequest<RoleDeletePermanentCommand,
    RoleDeletePermanentCommandHandler, Either<RoleDeletePermanentCommandResult>>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="RoleDeletePermanentCommand" /> class.
    /// </summary>
    public RoleDeletePermanentCommand()
        : base(typeof(RoleDeletePermanentCommand))
    {
    }

        /// <inheritdoc cref="RoleDeletePermanentCommand" />
        public required Guid RoleId { get; init; }
        

 


}