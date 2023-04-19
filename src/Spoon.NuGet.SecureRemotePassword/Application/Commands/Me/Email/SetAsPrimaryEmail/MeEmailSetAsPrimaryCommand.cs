namespace Spoon.NuGet.SecureRemotePassword.Application.Commands.Me.Email.SetAsPrimaryEmail;

using Core.Application;
using Core.Application.Interfaces;

/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseCommand" />.
/// </summary>
/// <seealso cref="MediatorBaseCommand" />
[PermissionPipelineBehaviourExclude("No claim required using Secure Remote Password ClientSessionProof")]
public sealed class MeEmailSetAsPrimaryCommand : MediatorBaseCommand, IHandleableRequest<MeEmailSetAsPrimaryCommand,
    MeEmailSetAsPrimaryCommandHandler, Either<MeEmailSetAsPrimaryCommandResult>>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="MeEmailSetAsPrimaryCommand" /> class.
    /// </summary>
    public MeEmailSetAsPrimaryCommand()
        : base(typeof(MeEmailSetAsPrimaryCommand))
    {
    }

    /// <inheritdoc cref="MeEmailSetAsPrimaryCommand" />
    public Guid UserId { internal get; set; }

    /// <inheritdoc cref="MeEmailSetAsPrimaryCommand" />
    public required Guid EmailId { get; init; }
}