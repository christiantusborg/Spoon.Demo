namespace Spoon.NuGet.SecureRemotePassword.Application.Administration.RemoveUserEmail;

using EitherCore;
using Mediator;
using Mediator.Interfaces;

/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseQuery" />.
/// </summary>
/// <seealso cref="MediatorBaseQuery" />
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