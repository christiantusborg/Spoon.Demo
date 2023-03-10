namespace Spoon.NuGet.SecureRemotePassword.Application.Me.ChangePassword;

using Spoon.NuGet.EitherCore;
using Spoon.NuGet.Mediator;
using Spoon.NuGet.Mediator.Interfaces;
using Spoon.NuGet.Mediator.PipelineBehaviors.Permission;

/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseQuery" />.
/// </summary>
/// <seealso cref="MediatorBaseQuery" />
[PermissionPipelineBehaviourExclude("No claim required using Secure Remote Password ClientSessionProof")]
public sealed class MeChangePasswordCommand : MediatorBaseCommand, IHandleableRequest<MeChangePasswordCommand,
    MeChangePasswordCommandHandler, Either<MeChangePasswordCommandResult>>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="MeChangePasswordCommand" /> class.
    /// </summary>
    public MeChangePasswordCommand()
        : base(typeof(MeChangePasswordCommand))
    {
    }

    /// <inheritdoc cref="MeChangePasswordCommand" />
    public 
        Guid UserId { get; init; }

    /// <inheritdoc cref="MeChangePasswordCommand" />
    public required string Verifier { get; init; }

    /// <inheritdoc cref="MeChangePasswordCommand" />
    public required string Salt { get; init; }
}