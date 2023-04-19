// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace Spoon.NuGet.SecureRemotePassword.Application.Commands.Me.Session.GetAll;

using Core.Application;
using Core.Application.Interfaces;

/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
///     Implements the <see cref="SessionGetAllCommand" />.
/// </summary>
/// <seealso cref="SessionGetAllCommand" />
public sealed class SessionGetAllCommand : MediatorBaseCommand, IHandleableRequest<SessionGetAllCommand,
    SessionGetAllCommandHandler, Either<BaseSearchCommandResult<SessionGetAllCommandResult>>>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="SessionGetAllCommand" /> class.
    /// </summary>
    public SessionGetAllCommand()
        : base(typeof(SessionGetAllCommand))
    {
    }

    /// <inheritdoc cref="SessionGetAllCommand" />
    public Guid UserId { get; set; }
}