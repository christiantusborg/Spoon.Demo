namespace Spoon.Demo.Application.V1.Products.Commands.DeletePermanent;

using FluentValidation;

/// <summary>
/// Class ProductDeletePermanentQueryValidator. This class cannot be inherited.
/// </summary>
public sealed class ProductDeletePermanentCommandValidator : AbstractValidator<ProductDeletePermanentCommand>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ProductDeletePermanentCommandValidator"/> class.
    /// </summary>
    public ProductDeletePermanentCommandValidator()
    {
        this.RuleFor(x => x.ProductId).NotNull()
            .WithMessage(this.GetType().Name + "_" + "NotNull" + "_" + "ProductId");
    }
}