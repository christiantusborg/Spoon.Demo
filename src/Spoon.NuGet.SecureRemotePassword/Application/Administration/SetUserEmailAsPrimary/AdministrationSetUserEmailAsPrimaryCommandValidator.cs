namespace Spoon.NuGet.SecureRemotePassword.Application.Administration.SetUserEmailAsPrimary;

using FluentValidation;

/// <summary>
///     Class ProductCreateQueryValidator. This class cannot be inherited.
/// </summary>
public sealed class AdministrationSetUserEmailAsPrimaryCommandValidator : AbstractValidator<AdministrationSetUserEmailAsPrimaryCommand>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="AdministrationSetUserEmailAsPrimaryCommandValidator" /> class.
    /// </summary>
    public AdministrationSetUserEmailAsPrimaryCommandValidator()
    {
        this.RuleFor(x => x.EmailId)
            .NotEmpty()
            .WithMessage(this.GetType().Name + "_" + "IsEmpty" + "_" + "EmailId")
            .NotEqual(Guid.Empty)
            .WithMessage(this.GetType().Name + "_" + "IsGuidEmpty" + "_" + "EmailId");

        this.RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage(this.GetType().Name + "_" + "IsEmpty" + "_" + "UserId")
            .NotEqual(Guid.Empty)
            .WithMessage(this.GetType().Name + "_" + "IsGuidEmpty" + "_" + "UserId");
    }
}