
namespace Spoon.NuGet.SecureRemotePassword.Application.Role.DeleteSoft;

using Spoon.NuGet.EitherCore;
using Spoon.NuGet.Mediator;
using Spoon.NuGet.Mediator.Interfaces;

/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseQuery" />.
/// </summary>
/// <seealso cref="MediatorBaseQuery" />
public sealed class RoleDeleteSoftCommand : MediatorBaseCommand, IHandleableRequest<RoleDeleteSoftCommand,
    RoleDeleteSoftCommandHandler, Either<RoleDeleteSoftCommandResult>>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="RoleDeleteSoftCommand" /> class.
    /// </summary>
    public RoleDeleteSoftCommand()
        : base(typeof(RoleDeleteSoftCommand))
    {
    }

    /// <inheritdoc cref="RoleDeleteSoftCommand" />
    public Guid RoleId { get; init; }



 


}