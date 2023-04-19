namespace Spoon.NuGet.SecureRemotePassword.Application.Commands.Me.Email.Delete;

using Core.Application;
using Core.Application.Interfaces;

/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseCommand" />.
/// </summary>
/// <seealso cref="MediatorBaseCommand" />
[PermissionPipelineBehaviourExclude("No claim required using Secure Remote Password ClientSessionProof")]
public sealed class MeEmailDeleteCommand : MediatorBaseCommand, IHandleableRequest<MeEmailDeleteCommand,
    MeEmailDeleteCommandHandler, Either<MeEmailDeleteCommandResult>>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="MeEmailDeleteCommand" /> class.
    /// </summary>
    public MeEmailDeleteCommand()
        : base(typeof(MeEmailDeleteCommand))
    {
    }

    /// <inheritdoc cref="MeEmailDeleteCommand" />
    public Guid UserId { internal get; set; }

    /// <inheritdoc cref="MeEmailDeleteCommand" />
    public required Guid EmailId { get; init; }
}