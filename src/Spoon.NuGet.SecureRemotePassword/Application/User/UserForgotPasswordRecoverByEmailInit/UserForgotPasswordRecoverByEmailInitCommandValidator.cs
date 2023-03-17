namespace Spoon.NuGet.SecureRemotePassword.Application.User.UserForgotPasswordRecoverByEmailInit;

using FluentValidation;

/// <summary>
///     Class ProductCreateQueryValidator. This class cannot be inherited.
/// </summary>
public sealed class UserForgotPasswordRecoverByEmailInitCommandValidator : AbstractValidator<UserForgotPasswordRecoverByEmailInitCommand>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="UserForgotPasswordRecoverByEmailInitCommandValidator" /> class.
    /// </summary>
    public UserForgotPasswordRecoverByEmailInitCommandValidator()
    {
        this.RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage(this.GetType().Name + "_" + "IsEmpty" + "_" + "Email")
            .EmailAddress()
            .WithMessage(this.GetType().Name + "_" + "IsNotEmailAddress" + "_" + "Email");
    }
}