// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace Spoon.NuGet.SecureRemotePassword.Application.Commands.Claim.GetAll;

using Domain.Entities;

/// <summary>
///     Class ProductCreateQueryResult. This class cannot be inherited.
/// </summary>
public sealed class ClaimGetAllCommandUserCommandResult
{
    /// <inheritdoc cref="ClaimGetAllCommandUserCommandResult" />
    public List<Claim> Claims { get; init; } = new ();
}