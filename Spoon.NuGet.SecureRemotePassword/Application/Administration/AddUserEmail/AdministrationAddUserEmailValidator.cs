namespace Spoon.NuGet.SecureRemotePassword.Application.Administration.AddUserEmail;

using FluentValidation;

/// <summary>
///     Class ProductCreateQueryValidator. This class cannot be inherited.
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
            .WithMessage(this.GetType().Name + "_" + "IsEmpty" + "_" + "UserId")
            .NotEqual(Guid.Empty)
            .WithMessage(this.GetType().Name + "_" + "IsGuidEmpty" + "_" + "UserId");
    }
}