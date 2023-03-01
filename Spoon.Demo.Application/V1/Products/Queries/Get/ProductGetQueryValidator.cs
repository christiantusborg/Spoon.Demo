namespace Spoon.Demo.Application.V1.Products.Queries.Get;

using FluentValidation;

/// <summary>
/// Class ProductGetQueryValidator. This class cannot be inherited.
/// </summary>
public sealed class ProductGetQueryValidator : AbstractValidator<ProductGetQuery>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ProductGetQueryValidator"/> class.
    /// </summary>
    public ProductGetQueryValidator()
    {
        this.RuleFor(x => x.ProductId).NotNull()
            .WithMessage(this.GetType().Name + "_" + "NotNull" + "_" + "ProductId");
        
        this.RuleFor(x => x.Name).NotNull()
            .WithMessage(this.GetType().Name + "_" + "NotNull" + "_" + "Name");
    }
}