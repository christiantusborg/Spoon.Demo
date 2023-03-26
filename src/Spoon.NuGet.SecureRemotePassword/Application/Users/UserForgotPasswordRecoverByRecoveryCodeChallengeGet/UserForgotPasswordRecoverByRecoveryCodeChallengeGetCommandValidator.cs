namespace Spoon.NuGet.SecureRemotePassword.Application.Users.UserForgotPasswordRecoverByRecoveryCodeChallengeGet;

using FluentValidation;

/// <summary>
///     Class ProductCreateQueryValidator. This class cannot be inherited.
/// </summary>
public sealed class UserForgotPasswordRecoverByRecoveryCodeChallengeGetCommandValidator : AbstractValidator<UserForgotPasswordRecoverByRecoveryCodeChallengeGetCommand>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="UserForgotPasswordRecoverByRecoveryCodeChallengeGetCommandValidator" /> class.
    /// </summary>
    public UserForgotPasswordRecoverByRecoveryCodeChallengeGetCommandValidator()
    {
        this.RuleFor(x => x.Email).NotEmpty()
            .WithMessage(this.GetType().Name + "_" + "IsEmpty" + "_" + "Username");
       
    }
}