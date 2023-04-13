// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Spoon.NuGet.SecureRemotePassword.Application.Administration.CreateUser;

using EitherCore;
using Mediator;
using Mediator.Interfaces;

/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseQuery" />.
/// </summary>
/// <seealso cref="MediatorBaseQuery" />
public sealed class AdministrationCreateUserCommand : MediatorBaseCommand, IHandleableRequest<AdministrationCreateUserCommand,
    AdministrationCreateUserCommandHandler, Either<AdministrationCreateUserCommandResult>>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="AdministrationCreateUserCommand" /> class.
    /// </summary>
    public AdministrationCreateUserCommand()
        : base(typeof(AdministrationCreateUserCommand))
    {
    }

    /// <inheritdoc cref="AdministrationCreateUserCommand" />
    public required string UsernameHash { get; init; }

    /// <inheritdoc cref="AdministrationCreateUserCommand" />
    public required string Email { get; init; }

    /// <inheritdoc cref="AdministrationCreateUserCommand" />
    public required string Verifier { get; init; }

    /// <inheritdoc cref="AdministrationCreateUserCommand" />
    public required string Salt { get; init; }
}