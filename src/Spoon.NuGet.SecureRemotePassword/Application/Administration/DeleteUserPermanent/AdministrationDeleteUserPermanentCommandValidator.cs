namespace Spoon.NuGet.SecureRemotePassword.Application.Administration.DeleteUserPermanent;

using FluentValidation;

/// <summary>
///     Class ProductCreateQueryValidator. This class cannot be inherited.
/// </summary>
public sealed class AdministrationDeleteUserPermanentCommandValidator : AbstractValidator<AdministrationDeleteUserPermanentCommand>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="AdministrationDeleteUserPermanentCommandValidator" /> class.
    /// </summary>
    public AdministrationDeleteUserPermanentCommandValidator()
    {
        this.RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage(this.GetType().Name + "_" + "IsEmpty" + "_" + "UserId")
            .NotEqual(Guid.Empty)
            .WithMessage(this.GetType().Name + "_" + "IsGuidEmpty" + "_" + "UserId");
    }
}