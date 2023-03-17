
namespace Spoon.NuGet.SecureRemotePassword.Application.Administration.AddUserEmail;

using Spoon.NuGet.EitherCore;
using Spoon.NuGet.Mediator;
using Spoon.NuGet.Mediator.Interfaces;

/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseQuery" />.
/// </summary>
/// <seealso cref="MediatorBaseQuery" />
public sealed class AdministrationAddUserEmailCommand : MediatorBaseCommand, IHandleableRequest<AdministrationAddUserEmailCommand,
    AdministrationAddUserEmailCommandHandler, Either<AdministrationAddUserEmailCommandResult>>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="AdministrationAddUserEmailCommand" /> class.
    /// </summary>
    public AdministrationAddUserEmailCommand()
        : base(typeof(AdministrationAddUserEmailCommand))
    {
    }

    /// <inheritdoc cref="AdministrationAddUserEmailCommand" />
    public Guid UserId { get; init; }
    /// <inheritdoc cref="AdministrationAddUserEmailCommand" />
    public required string Email { get; init; }



}