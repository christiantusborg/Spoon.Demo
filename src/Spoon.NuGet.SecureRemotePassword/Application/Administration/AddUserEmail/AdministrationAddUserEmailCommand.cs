namespace Spoon.NuGet.SecureRemotePassword.Application.Administration.AddUserEmail;

using EitherCore;
using Mediator;
using Mediator.Interfaces;

/// <summary>
/// A MediatR command that adds an email address for a user in the administration context.
/// </summary>
public sealed class AdministrationAddUserEmailCommand : MediatorBaseCommand, IHandleableRequest<AdministrationAddUserEmailCommand,
    AdministrationAddUserEmailCommandHandler, Either<AdministrationAddUserEmailCommandResult>>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AdministrationAddUserEmailCommand"/> class.
    /// </summary>
    public AdministrationAddUserEmailCommand()
        : base(typeof(AdministrationAddUserEmailCommand))
    {
    }

    /// <summary>
    /// Gets or sets the unique identifier of the user for whom the email is being added.
    /// </summary>
    public Guid UserId { get; init; }

    /// <summary>
    /// Gets or sets the email address to be added for the user.
    /// </summary>
    public required string Email { get; init; }
}