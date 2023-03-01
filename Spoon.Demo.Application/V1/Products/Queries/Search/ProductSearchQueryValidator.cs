namespace Spoon.Demo.Application.V1.Products.Queries.Search;

using FluentValidation;

/// <summary>
/// Class ProductSearchQueryValidator. This class cannot be inherited.
/// </summary>
public sealed class ProductSearchQueryValidator : AbstractValidator<ProductSearchQuery>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ProductSearchQueryValidator"/> class.
    /// </summary>
    public ProductSearchQueryValidator()
    {
        this.RuleFor(x => x.ProductId).NotNull()
            .WithMessage(this.GetType().Name + "_" + "NotNull" + "_" + "ProductId");
    }
}