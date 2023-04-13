
// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Spoon.NuGet.SecureRemotePassword.Application.Roles.Update;

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
    public Guid RoleId { get; init; }
    /// <inheritdoc cref="RoleUpdateCommand" />
    public required string Name { get; init; }
}