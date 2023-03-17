namespace Spoon.NuGet.SecureRemotePassword.Application.Administration.SetUserFailedLockout;

using FluentValidation;

/// <summary>
///     Class ProductCreateQueryValidator. This class cannot be inherited.
/// </summary>
public sealed class AdministrationSetUserFailedLockoutValidator : AbstractValidator<AdministrationSetUserFailedLockoutCommand>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="AdministrationSetUserFailedLockoutValidator" /> class.
    /// </summary>
    public AdministrationSetUserFailedLockoutValidator()
    {
        this.RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage(this.GetType().Name + "_" + "IsEmpty" + "_" + "UserId")
            .NotEqual(Guid.Empty)
            .WithMessage(this.GetType().Name + "_" + "IsGuidEmpty" + "_" + "UserId");
    }
}