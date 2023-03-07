namespace Spoon.NuGet.SecureRemotePassword.Application.Administration.RemoveUserEmail;

using FluentValidation;

/// <summary>
///     Class ProductCreateQueryValidator. This class cannot be inherited.
/// </summary>
public sealed class AdministrationRemoveUserEmailCommandValidator : AbstractValidator<AdministrationRemoveUserEmailCommand>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="AdministrationRemoveUserEmailCommandValidator" /> class.
    /// </summary>
    public AdministrationRemoveUserEmailCommandValidator()
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