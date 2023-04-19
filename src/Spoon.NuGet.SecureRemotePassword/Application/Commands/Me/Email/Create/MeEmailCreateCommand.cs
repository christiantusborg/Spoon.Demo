namespace Spoon.NuGet.SecureRemotePassword.Application.Commands.Me.Email.Create;

using Core.Application;
using Core.Application.Interfaces;

/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseCommand" />.
/// </summary>
/// <seealso cref="MediatorBaseCommand" />
[PermissionPipelineBehaviourExclude("No claim required using Secure Remote Password ClientSessionProof")]
public sealed class MeEmailCreateCommand : MediatorBaseCommand, IHandleableRequest<MeEmailCreateCommand,
    MeEmailCreateCommandHandler, Either<MeEmailCreateCommandResult>>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="MeEmailCreateCommand" /> class.
    /// </summary>
    public MeEmailCreateCommand()
        : base(typeof(MeEmailCreateCommand))
    {
    }

    /// <inheritdoc cref="MeEmailCreateCommand" />
    public Guid UserId { get; init; }

    /// <inheritdoc cref="MeEmailCreateCommand" />
    public required string Email { get; init; }
}