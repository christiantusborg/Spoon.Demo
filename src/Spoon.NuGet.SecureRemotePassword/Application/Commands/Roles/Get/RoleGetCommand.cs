namespace Spoon.NuGet.SecureRemotePassword.Application.Commands.Roles.Get;

using Core.Application;
using Core.Application.Interfaces;

/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseCommand" />.
/// </summary>
/// <seealso cref="MediatorBaseCommand" />
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