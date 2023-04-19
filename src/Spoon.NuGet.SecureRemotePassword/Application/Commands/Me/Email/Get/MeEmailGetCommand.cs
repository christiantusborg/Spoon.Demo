namespace Spoon.NuGet.SecureRemotePassword.Application.Commands.Me.Email.Get;

using Core.Application;
using Core.Application.Interfaces;

/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseCommand" />.
/// </summary>
/// <seealso cref="MediatorBaseCommand" />
[PermissionPipelineBehaviourExclude("No claim required using Secure Remote Password ClientSessionProof")]
public sealed class MeEmailGetCommand : MediatorBaseCommand, IHandleableRequest<MeEmailGetCommand,
    MeEmailGetCommandHandler, Either<MeEmailGetCommandResult>>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="MeEmailGetCommand" /> class.
    /// </summary>
    public MeEmailGetCommand()
        : base(typeof(MeEmailGetCommand))
    {
    }

    /// <inheritdoc cref="MeEmailGetCommand" />
    public Guid EmailId { get; init; }

    /// <inheritdoc cref="MeEmailGetCommand" />
    public Guid UserId { get; set; }
}