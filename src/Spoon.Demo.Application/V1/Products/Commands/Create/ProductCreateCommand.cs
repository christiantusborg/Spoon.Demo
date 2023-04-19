namespace Spoon.Demo.Application.V1.Products.Commands.Create;

using System.Security.Claims;
using NuGet.Core.Application;
using NuGet.Core.Application.Interfaces;
using NuGet.Core.Application.Mediator.PipelineBehaviors.Permission;
using NuGet.Core.EitherCore;

/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseQuery" />.
/// </summary>
/// <seealso cref="MediatorBaseQuery" />
[PermissionPipelineBehaviourExclude("")]
public sealed class ProductCreateCommand : MediatorBaseCommand, IHandleableRequest<ProductCreateCommand,
    ProductCreateCommandHandler, Either<ProductCreateCommandResult>>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="ProductCreateCommand" /> class.
    /// </summary>
    public ProductCreateCommand()
        : base(typeof(ProductCreateCommand))
    {
    }

    /// <summary>
    ///     Gets or sets the product identifier.
    /// </summary>
    /// <value>The product identifier.</value>
    public Guid ProductId { get; set; }

    public override IEnumerable<Claim> GetRequiredClaims()
    {
        var defaultRequiredClaims = base.GetRequiredClaims().ToList();

        defaultRequiredClaims.Add(new ("CustomClaim", "CustomClaim"));

        return defaultRequiredClaims;
    }
}