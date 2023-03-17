namespace Spoon.Demo.Application.V1.Products.Commands.Create;

using FluentValidation;

/// <summary>
/// Class ProductCreateQueryValidator. This class cannot be inherited.
/// </summary>
public sealed class ProductCreateCommandValidator : AbstractValidator<ProductCreateCommand>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ProductCreateCommandValidator"/> class.
    /// </summary>
    public ProductCreateCommandValidator()
    {
        this.RuleFor(x => x.ProductId).NotNull()
            .WithMessage(this.GetType().Name + "_" + "NotNull" + "_" + "ProductId");
    }
}