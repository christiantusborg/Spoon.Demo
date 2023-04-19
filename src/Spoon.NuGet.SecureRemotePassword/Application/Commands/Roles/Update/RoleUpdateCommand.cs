// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace Spoon.NuGet.SecureRemotePassword.Application.Commands.Roles.Update;

using Core.Application;
using Core.Application.Interfaces;

/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseCommand" />.
/// </summary>
/// <seealso cref="MediatorBaseCommand" />
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