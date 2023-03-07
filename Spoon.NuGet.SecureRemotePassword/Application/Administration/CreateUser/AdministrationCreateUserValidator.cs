namespace Spoon.NuGet.SecureRemotePassword.Application.Administration.CreateUser;

using FluentValidation;

/// <summary>
///     Class ProductCreateQueryValidator. This class cannot be inherited.
/// </summary>
public sealed class AdministrationCreateUserValidator : AbstractValidator<AdministrationCreateUserCommand>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="AdministrationCreateUserValidator" /> class.
    /// </summary>
    public AdministrationCreateUserValidator()
    {
        this.RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage(this.GetType().Name + "_" + "IsEmpty" + "_" + "UserId");

        this.RuleFor(x => x.Salt)
            .NotEmpty()
            .WithMessage(this.GetType().Name + "_" + "IsEmpty" + "_" + "Salt");

        this.RuleFor(x => x.Verifier)
            .NotEmpty()
            .WithMessage(this.GetType().Name + "_" + "IsEmpty" + "_" + "Verifier");
    }
}