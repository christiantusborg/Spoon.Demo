namespace Spoon.NuGet.SecureRemotePassword.Application.Administration.SetUserAllowedLogin;

using FluentValidation;

/// <summary>
///     Class ProductCreateQueryValidator. This class cannot be inherited.
/// </summary>
public sealed class AdministrationSetUserAllowedLoginValidator : AbstractValidator<AdministrationSetUserAllowedLoginCommand>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="AdministrationSetUserAllowedLoginValidator" /> class.
    /// </summary>
    public AdministrationSetUserAllowedLoginValidator()
    {
        this.RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage(this.GetType().Name + "_" + "IsEmpty" + "_" + "UserId")
            .NotEqual(Guid.Empty)
            .WithMessage(this.GetType().Name + "_" + "IsGuidEmpty" + "_" + "UserId");
    }
}