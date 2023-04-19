// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace Spoon.NuGet.SecureRemotePassword.Application.Commands.Administration.GetUser;

using Core.Application;
using Core.Application.Interfaces;

/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseCommand" />.
/// </summary>
/// <seealso cref="MediatorBaseCommand" />
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