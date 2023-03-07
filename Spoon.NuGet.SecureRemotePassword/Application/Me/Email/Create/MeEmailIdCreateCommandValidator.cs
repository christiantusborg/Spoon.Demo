namespace Spoon.NuGet.SecureRemotePassword.Application.Me.Email.Create;

using FluentValidation;

/// <summary>
///     Class ProductCreateQueryValidator. This class cannot be inherited.
/// </summary>
public sealed class MeEmailIdCreateCommandValidator : AbstractValidator<MeEmailCreateEmailCommand>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="MeEmailIdCreateCommandValidator" /> class.
    /// </summary>
    public MeEmailIdCreateCommandValidator()
    {
        this.RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage(this.GetType().Name + "_" + "IsEmpty" + "_" + "Email")
            .EmailAddress()
            .WithMessage(this.GetType().Name + "_" + "IsNotEmailAddress" + "_" + "Email");

        this.RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage(this.GetType().Name + "_" + "IsEmpty" + "_" + "UserId")
            .NotEqual(Guid.Empty)
            .WithMessage(this.GetType().Name + "_" + "IsGuidEmpty" + "_" + "UserId");
    }
}