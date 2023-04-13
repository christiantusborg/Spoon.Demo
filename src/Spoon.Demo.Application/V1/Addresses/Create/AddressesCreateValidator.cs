namespace Spoon.Demo.Application.V1.Addresses.Create;

using FluentValidation;

/// <summary>
///     Class ProductCreateQueryValidator. This class cannot be inherited.
/// </summary>
public sealed class AddressesCreateValidator : AbstractValidator<AddressesCreateCommand>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="AddressesCreateValidator" /> class.
    /// </summary>
    public AddressesCreateValidator()
    {
        this.RuleFor(x => x.AddressOne)
            .NotEmpty()
            .WithMessage(this.GetType().Name + "_" + "IsEmpty" + "_" + "AddressOne");

        this.RuleFor(x => x.Zip)
            .NotEmpty()
            .WithMessage(this.GetType().Name + "_" + "IsEmpty" + "_" + "Zip");

        this.RuleFor(x => x.City)
            .NotEmpty()
            .WithMessage(this.GetType().Name + "_" + "IsEmpty" + "_" + "City");
        
        this.RuleFor(x => x.Country)
            .NotEmpty()
            .WithMessage(this.GetType().Name + "_" + "IsEmpty" + "_" + "Country");
        
        this.RuleFor(x => x.CustomerId)
            .NotEqual(Guid.NewGuid())
            .WithMessage(this.GetType().Name + "_" + "IsEmptyGuid" + "_" + "CustomerId");

    }
}