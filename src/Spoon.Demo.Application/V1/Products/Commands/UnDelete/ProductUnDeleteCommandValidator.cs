namespace Spoon.Demo.Application.V1.Products.Commands.UnDelete;

using FluentValidation;

/// <summary>
/// Class ProductDeleteQueryValidator. This class cannot be inherited.
/// </summary>
public sealed class ProductUnDeleteCommandValidator : AbstractValidator<ProductUnDeleteCommand>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ProductUnDeleteCommandValidator"/> class.
    /// </summary>
    public ProductUnDeleteCommandValidator()
    {
        this.RuleFor(x => x.ProductId).NotNull()
            .WithMessage(this.GetType().Name + "_" + "NotNull" + "_" + "ProductId");
    }
}