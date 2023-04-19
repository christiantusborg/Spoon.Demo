namespace Spoon.NuGet.SecureRemotePassword.Application.Commands.Me.Delete.Soft;

using Core.Application;
using Core.Application.Interfaces;

/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseCommand" />.
/// </summary>
/// <seealso cref="MediatorBaseCommand" />
[PermissionPipelineBehaviourExclude("No claim required using Secure Remote Password ClientSessionProof")]
public sealed class MeDeleteSoftCommand : MediatorBaseCommand, IHandleableRequest<MeDeleteSoftCommand,
    MeDeleteSoftCommandHandler, Either<MeDeleteSoftCommandResult>>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="MeDeleteSoftCommand" /> class.
    /// </summary>
    public MeDeleteSoftCommand()
        : base(typeof(MeDeleteSoftCommand))
    {
    }

    /// <inheritdoc cref="MeDeleteSoftCommand" />
    public
        Guid UserId { get; init; }
}