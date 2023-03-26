namespace Spoon.NuGet.SecureRemotePassword.Application.Administration.DeleteUserSoft;

using FluentValidation;

/// <summary>
///     Class ProductCreateQueryValidator. This class cannot be inherited.
/// </summary>
public sealed class AdministrationDeleteUserSoftCommandValidator : AbstractValidator<AdministrationDeleteUserSoftCommand>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="AdministrationDeleteUserSoftCommandValidator" /> class.
    /// </summary>
    public AdministrationDeleteUserSoftCommandValidator()
    {
        this.RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage(this.GetType().Name + "_" + "IsEmpty" + "_" + "UserId")
            .NotEqual(Guid.Empty)
            .WithMessage(this.GetType().Name + "_" + "IsGuidEmpty" + "_" + "UserId");
    }
}