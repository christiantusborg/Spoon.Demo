namespace Spoon.NuGet.SecureRemotePassword.Application.Commands.Roles.DeleteSoft;

using Core.Application;
using Core.Application.Interfaces;

/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseCommand" />.
/// </summary>
/// <seealso cref="MediatorBaseCommand" />
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