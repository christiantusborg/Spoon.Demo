namespace Spoon.Demo.Application.V1.Addresses.DeleteSoft;

using FluentValidation;

/// <summary>
///     Class ProductCreateQueryValidator. This class cannot be inherited.
/// </summary>
public sealed class AddressesDeleteUserSoftCommandValidator : AbstractValidator<AddressesDeleteUserSoftCommand>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="AddressesDeleteUserSoftCommandValidator" /> class.
    /// </summary>
    public AddressesDeleteUserSoftCommandValidator()
    {
        this.RuleFor(x => x.CustomerId)
            .NotEmpty()
            .WithMessage(this.GetType().Name + "_" + "IsEmpty" + "_" + "CustomerId")
            .NotEqual(Guid.Empty)
            .WithMessage(this.GetType().Name + "_" + "IsGuidEmpty" + "_" + "CustomerId");
        
        this.RuleFor(x => x.AddressId)
            .NotEmpty()
            .WithMessage(this.GetType().Name + "_" + "IsEmpty" + "_" + "AddressId")
            .NotEqual(Guid.Empty)
            .WithMessage(this.GetType().Name + "_" + "IsGuidEmpty" + "_" + "AddressId");
    }
}