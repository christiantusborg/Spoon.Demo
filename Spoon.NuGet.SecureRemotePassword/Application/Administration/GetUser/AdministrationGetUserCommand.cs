
namespace Spoon.NuGet.SecureRemotePassword.Application.Administration.GetUser;

using Spoon.NuGet.EitherCore;
using Spoon.NuGet.Mediator;
using Spoon.NuGet.Mediator.Interfaces;

/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseQuery" />.
/// </summary>
/// <seealso cref="MediatorBaseQuery" />
public sealed class AdministrationGetUserCommand : MediatorBaseCommand, IHandleableRequest<AdministrationGetUserCommand,
    AdministrationGetUserCommandHandler, Either<AdministrationGetUserCommandResult>>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="AdministrationGetUserCommand" /> class.
    /// </summary>
    public AdministrationGetUserCommand()
        : base(typeof(AdministrationGetUserCommand))
    {
    }

    /// <inheritdoc cref="AdministrationGetUserCommand" />
    public required Guid UserId { get; init; }
}