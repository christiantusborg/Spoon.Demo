namespace Spoon.NuGet.SecureRemotePassword.Application.Users.UserForgotPasswordRecoverByEmailSet;

using FluentValidation;

/// <summary>
///     Class ProductCreateQueryValidator. This class cannot be inherited.
/// </summary>
public sealed class UserForgotPasswordRecoverByEmailSetCommandValidator : AbstractValidator<UserForgotPasswordRecoverByEmailSetCommand>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="UserForgotPasswordRecoverByEmailSetCommandValidator" /> class.
    /// </summary>
    public UserForgotPasswordRecoverByEmailSetCommandValidator()
    {
        this.RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage(this.GetType().Name + "_" + "IsEmpty" + "_" + "Email")
            .EmailAddress()
            .WithMessage(this.GetType().Name + "_" + "IsNotEmailAddress" + "_" + "Email");
        
        this.RuleFor(x => x.Proof).NotEmpty()
            .WithMessage(this.GetType().Name + "_" + "IsEmpty" + "_" + "UserId");
        
        this.RuleFor(x => x.Salt).NotNull()
            .WithMessage(this.GetType().Name + "_" + "IsNull" + "_" + "Salt");
        
        this.RuleFor(x => x.Verifier).NotNull()
            .WithMessage(this.GetType().Name + "_" + "IsNull" + "_" + "Verifier");
        
    }
}