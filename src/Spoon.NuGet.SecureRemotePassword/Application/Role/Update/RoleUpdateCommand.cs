
namespace Spoon.NuGet.SecureRemotePassword.Application.Role.Update;

using Spoon.NuGet.EitherCore;
using Spoon.NuGet.Mediator;
using Spoon.NuGet.Mediator.Interfaces;

/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseQuery" />.
/// </summary>
/// <seealso cref="MediatorBaseQuery" />
public sealed class RoleUpdateCommand : MediatorBaseCommand, IHandleableRequest<RoleUpdateCommand,
    RoleUpdateCommandHandler, Either<RoleUpdateCommandResult>>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="RoleUpdateCommand" /> class.
    /// </summary>
    public RoleUpdateCommand()
        : base(typeof(RoleUpdateCommand))
    {
    }

    /// <inheritdoc cref="RoleUpdateCommand" />
    public required string Email { get; init; }
    /// <inheritdoc cref="RoleUpdateCommand" />
    public required string Verifier { get; init; }
    /// <inheritdoc cref="RoleUpdateCommand" />
    public required string Salt { get; init; }

 


}