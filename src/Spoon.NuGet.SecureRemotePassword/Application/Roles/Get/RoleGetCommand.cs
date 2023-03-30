
namespace Spoon.NuGet.SecureRemotePassword.Application.Roles.Get;

using Spoon.NuGet.EitherCore;
using Spoon.NuGet.Mediator;
using Spoon.NuGet.Mediator.Interfaces;

/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseQuery" />.
/// </summary>
/// <seealso cref="MediatorBaseQuery" />
public sealed class RoleGetCommand : MediatorBaseCommand, IHandleableRequest<RoleGetCommand,
    RoleGetCommandHandler, Either<RoleGetCommandResult>>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="RoleGetCommand" /> class.
    /// </summary>
    public RoleGetCommand()
        : base(typeof(RoleGetCommand))
    {
    }

    /// <inheritdoc cref="RoleGetCommand" />
    public Guid RoleId { get; init; }

 


}