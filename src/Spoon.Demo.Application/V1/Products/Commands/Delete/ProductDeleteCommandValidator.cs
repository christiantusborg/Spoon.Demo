namespace Spoon.Demo.Application.V1.Products.Commands.Delete;

using FluentValidation;

/// <summary>
/// Class ProductDeleteQueryValidator. This class cannot be inherited.
/// </summary>
public sealed class ProductDeleteCommandValidator : AbstractValidator<ProductDeleteCommand>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ProductDeleteCommandValidator"/> class.
    /// </summary>
    public ProductDeleteCommandValidator()
    {
        this.RuleFor(x => x.ProductId).NotNull()
            .WithMessage(this.GetType().Name + "_" + "NotNull" + "_" + "ProductId");
    }
}