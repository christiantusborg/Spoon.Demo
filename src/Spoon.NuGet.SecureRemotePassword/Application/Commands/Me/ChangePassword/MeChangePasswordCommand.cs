namespace Spoon.NuGet.SecureRemotePassword.Application.Commands.Me.ChangePassword;

using Core.Application;
using Core.Application.Interfaces;

/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseCommand" />.
/// </summary>
/// <seealso cref="MediatorBaseCommand" />
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