namespace Spoon.Demo.Application.V1.Products.Commands.Update;

using FluentValidation;

/// <summary>
/// Class ProductUpdateQueryValidator. This class cannot be inherited.
/// </summary>
public sealed class ProductUpdateCommandValidator : AbstractValidator<ProductUpdateCommand>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ProductUpdateCommandValidator"/> class.
    /// </summary>
    public ProductUpdateCommandValidator()
    {
        this.RuleFor(x => x.ProductId).NotNull()
            .WithMessage(this.GetType().Name + "_" + "NotNull" + "_" + "ProductId");
    }
}