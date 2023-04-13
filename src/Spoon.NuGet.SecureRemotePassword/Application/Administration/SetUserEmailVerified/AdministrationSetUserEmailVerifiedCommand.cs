// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace Spoon.NuGet.SecureRemotePassword.Application.Administration.SetUserEmailVerified;

using EitherCore;
using Mediator;
using Mediator.Interfaces;

/// <summary>
///     A MediatR command that adds an email address for a user in the administration context.
/// </summary>
public sealed class AdministrationSetUserEmailVerifiedCommand : MediatorBaseCommand, IHandleableRequest<AdministrationSetUserEmailVerifiedCommand,
    AdministrationSetUserEmailVerifiedCommandHandler, Either<AdministrationSetUserEmailVerifiedCommandResult>>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="AdministrationSetUserEmailVerifiedCommand" /> class.
    /// </summary>
    public AdministrationSetUserEmailVerifiedCommand()
        : base(typeof(AdministrationSetUserEmailVerifiedCommand))
    {
    }

    /// <summary>
    ///     Gets or sets the unique identifier of the email is being affected.
    /// </summary>
    public Guid EmailId { get; init; }

    /// <summary>
    ///   Gets or sets the unique identifier of the user.
    /// </summary>
    public bool Verified { get; init; }
}