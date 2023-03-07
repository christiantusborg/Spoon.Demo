namespace Spoon.NuGet.SecureRemotePassword.Application.Administration.SetUserPassword;

using FluentValidation;

/// <summary>
///     Class ProductCreateQueryValidator. This class cannot be inherited.
/// </summary>
public sealed class AdministrationSetUserPasswordValidator : AbstractValidator<AdministrationSetUserPasswordCommand>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="AdministrationSetUserPasswordValidator" /> class.
    /// </summary>
    public AdministrationSetUserPasswordValidator()
    {
        this.RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage(this.GetType().Name + "_" + "IsEmpty" + "_" + "UserId")
            .NotEqual(Guid.Empty)
            .WithMessage(this.GetType().Name + "_" + "IsGuidEmpty" + "_" + "UserId");
    }
}