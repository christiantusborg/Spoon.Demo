namespace Spoon.NuGet.SecureRemotePassword.Application.Administration.AddUserEmail;

using FluentValidation;

/// <summary>
///     Validator for <see cref="AdministrationAddUserEmailCommand" />.
/// </summary>
public sealed class AdministrationAddUserEmailValidator : AbstractValidator<AdministrationAddUserEmailCommand>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="AdministrationAddUserEmailValidator" /> class.
    /// </summary>
    public AdministrationAddUserEmailValidator()
    {
        this.RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage($"{this.GetType().Name}_IsEmpty_UserId")
            .NotEqual(Guid.Empty)
            .WithMessage($"{this.GetType().Name}_InvalidGuid_UserId");

        this.RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage($"{this.GetType().Name}_IsEmpty_Email")
            .EmailAddress()
            .WithMessage($"{this.GetType().Name}_InvalidEmailFormat_Email");
    }
}