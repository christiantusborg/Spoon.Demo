// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace Spoon.NuGet.SecureRemotePassword.Application.Commands.Me.Email.GetAll;

using Core.Application;
using Core.Application.Interfaces;

/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseCommand" />.
/// </summary>
/// <seealso cref="MediatorBaseCommand" />
[PermissionPipelineBehaviourExclude("No claim required using Secure Remote Password ClientSessionProof")]
public sealed class MeEmailGetAllCommand : MediatorBaseCommand, IHandleableRequest<MeEmailGetAllCommand,
    MeEmailGetAllCommandHandler, Either<BaseSearchCommandResultExtendedWithUserId<MeEmailGetAllCommandResult>>>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="MeEmailGetAllCommand" /> class.
    /// </summary>
    public MeEmailGetAllCommand()
        : base(typeof(MeEmailGetAllCommand))
    {
    }

    /// <inheritdoc cref="MeEmailGetAllCommand" />
    public Guid UserId { get; init; }
}