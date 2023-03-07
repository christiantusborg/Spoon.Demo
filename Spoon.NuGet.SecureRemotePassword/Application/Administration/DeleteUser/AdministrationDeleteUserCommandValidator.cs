namespace Spoon.NuGet.SecureRemotePassword.Application.Administration.DeleteUser;

using FluentValidation;

/// <summary>
///     Class ProductCreateQueryValidator. This class cannot be inherited.
/// </summary>
public sealed class AdministrationDeleteUserCommandValidator : AbstractValidator<AdministrationDeleteUserCommand>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="AdministrationDeleteUserCommandValidator" /> class.
    /// </summary>
    public AdministrationDeleteUserCommandValidator()
    {
        this.RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage(this.GetType().Name + "_" + "IsEmpty" + "_" + "UserId")
            .NotEqual(Guid.Empty)
            .WithMessage(this.GetType().Name + "_" + "IsGuidEmpty" + "_" + "UserId");
    }
}