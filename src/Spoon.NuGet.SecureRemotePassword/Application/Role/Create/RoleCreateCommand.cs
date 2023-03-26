
namespace Spoon.NuGet.SecureRemotePassword.Application.Role.Create;

using Spoon.NuGet.EitherCore;
using Spoon.NuGet.Mediator;
using Spoon.NuGet.Mediator.Interfaces;





/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseQuery" />.
/// </summary>
/// <seealso cref="MediatorBaseQuery" />
public sealed class RoleCreateCommand : MediatorBaseCommand, IHandleableRequest<RoleCreateCommand,
    RoleCreateCommandHandler, Either<RoleCreateCommandResult>>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="RoleCreateCommand" /> class.
    /// </summary>
    public RoleCreateCommand()
        : base(typeof(RoleCreateCommand))
    {
    }

    /// <inheritdoc cref="RoleCreateCommand" />
    public required string Name { get; init; }
}