namespace Spoon.NuGet.SecureRemotePassword.Application.Commands.Administration.RemoveUserEmail;

using Core.Application;
using Core.Application.Interfaces;

/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseCommand" />.
/// </summary>
/// <seealso cref="MediatorBaseCommand" />
public sealed class AdministrationRemoveUserEmailCommand : MediatorBaseCommand, IHandleableRequest<AdministrationRemoveUserEmailCommand,
    AdministrationRemoveUserEmailCommandHandler, Either<AdministrationRemoveUserEmailCommandResult>>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="AdministrationRemoveUserEmailCommand" /> class.
    /// </summary>
    public AdministrationRemoveUserEmailCommand()
        : base(typeof(AdministrationRemoveUserEmailCommand))
    {
    }

    /// <inheritdoc cref="AdministrationRemoveUserEmailCommand" />
    public Guid UserId { get; init; }

    /// <inheritdoc cref="AdministrationRemoveUserEmailCommand" />
    public required Guid EmailId { get; init; }
}