namespace Spoon.NuGet.SecureRemotePassword.Application.Administration.SetUserEmailAsPrimary;

using Spoon.NuGet.EitherCore;
using Spoon.NuGet.Mediator;
using Spoon.NuGet.Mediator.Interfaces;

/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseQuery" />.
/// </summary>
/// <seealso cref="MediatorBaseQuery" />
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