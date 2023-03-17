namespace Spoon.NuGet.SecureRemotePassword.Application.Administration.SetUserMustChangePassword;

using FluentValidation;

/// <summary>
///     Class ProductCreateQueryValidator. This class cannot be inherited.
/// </summary>
public sealed class AdministrationSetUserMustChangePasswordValidator : AbstractValidator<AdministrationSetUserMustChangePasswordCommand>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="AdministrationSetUserMustChangePasswordValidator" /> class.
    /// </summary>
    public AdministrationSetUserMustChangePasswordValidator()
    {
        this.RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage(this.GetType().Name + "_" + "IsEmpty" + "_" + "UserId")
            .NotEqual(Guid.Empty)
            .WithMessage(this.GetType().Name + "_" + "IsGuidEmpty" + "_" + "UserId");
    }
}