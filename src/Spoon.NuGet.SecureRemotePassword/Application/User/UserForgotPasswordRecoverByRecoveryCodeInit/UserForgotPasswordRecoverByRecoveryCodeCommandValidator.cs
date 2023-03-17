namespace Spoon.NuGet.SecureRemotePassword.Application.User.UserForgotPasswordRecoverByRecoveryCodeInit;

using FluentValidation;

/// <summary>
///     Class ProductCreateQueryValidator. This class cannot be inherited.
/// </summary>
public sealed class UserForgotPasswordRecoverByRecoveryCodeCommandValidator : AbstractValidator<UserForgotPasswordRecoverByRecoveryCodeCommand>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="UserForgotPasswordRecoverByRecoveryCodeCommandValidator" /> class.
    /// </summary>
    public UserForgotPasswordRecoverByRecoveryCodeCommandValidator()
    {
        this.RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage(this.GetType().Name + "_" + "IsEmpty" + "_" + "Email")
            .EmailAddress()
            .WithMessage(this.GetType().Name + "_" + "IsNotEmailAddress" + "_" + "Email");
        
        this.RuleFor(x => x.Salt).NotNull()
            .WithMessage(this.GetType().Name + "_" + "IsNull" + "_" + "Salt");
        
        this.RuleFor(x => x.RecoveryCode).NotEmpty()
            .WithMessage(this.GetType().Name + "_" + "IsEmpty" + "_" + "RecoveryCode");
        
        this.RuleFor(x => x.Verifier).NotNull()
            .WithMessage(this.GetType().Name + "_" + "IsNull" + "_" + "Verifier");
        
    }
}