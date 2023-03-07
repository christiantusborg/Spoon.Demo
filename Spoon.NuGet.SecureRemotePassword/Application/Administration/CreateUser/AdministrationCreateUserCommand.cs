
namespace Spoon.NuGet.SecureRemotePassword.Application.Administration.CreateUser;

using Spoon.NuGet.EitherCore;
using Spoon.NuGet.Mediator;
using Spoon.NuGet.Mediator.Interfaces;

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
    public required string Email { get; init; }
    /// <inheritdoc cref="AdministrationCreateUserCommand" />
    public required string Verifier { get; init; }
    /// <inheritdoc cref="AdministrationCreateUserCommand" />
    public required string Salt { get; init; }

 


}