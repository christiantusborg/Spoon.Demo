namespace Spoon.NuGet.SecureRemotePassword.Application.Commands.Administration.SetUserEmailAsPrimary;

using Core.Application;
using Core.Application.Interfaces;

/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseCommand" />.
/// </summary>
/// <seealso cref="MediatorBaseCommand" />
public sealed class AdministrationSetUserEmailAsPrimaryCommand : MediatorBaseCommand, IHandleableRequest<AdministrationSetUserEmailAsPrimaryCommand,
    AdministrationSetUserEmailAsPrimaryCommandHandler, Either<AdministrationSetUserEmailAsPrimaryCommandResult>>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="AdministrationSetUserEmailAsPrimaryCommand" /> class.
    /// </summary>
    public AdministrationSetUserEmailAsPrimaryCommand()
        : base(typeof(AdministrationSetUserEmailAsPrimaryCommand))
    {
    }

    /// <inheritdoc cref="AdministrationSetUserEmailAsPrimaryCommand" />
    public
        Guid UserId { get; init; }

    /// <inheritdoc cref="AdministrationSetUserEmailAsPrimaryCommand" />
    public required Guid EmailId { get; init; }
}