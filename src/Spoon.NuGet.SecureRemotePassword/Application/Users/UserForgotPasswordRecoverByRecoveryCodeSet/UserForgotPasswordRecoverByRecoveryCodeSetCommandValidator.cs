namespace Spoon.NuGet.SecureRemotePassword.Application.Users.UserForgotPasswordRecoverByRecoveryCodeSet;

using FluentValidation;

/// <summary>
///     Class ProductCreateQueryValidator. This class cannot be inherited.
/// </summary>
public sealed class UserForgotPasswordRecoverByRecoveryCodeCSetCommandValidator : AbstractValidator<UserForgotPasswordRecoverByRecoveryCodeSetCommand>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="UserForgotPasswordRecoverByRecoveryCodeCSetCommandValidator" /> class.
    /// </summary>
    public UserForgotPasswordRecoverByRecoveryCodeCSetCommandValidator()
    {
        this.RuleFor(x => x.Salt).NotNull()
            .WithMessage(this.GetType().Name + "_" + "IsNull" + "_" + "Salt");
        
        this.RuleFor(x => x.Verifier).NotNull()
            .WithMessage(this.GetType().Name + "_" + "IsNull" + "_" + "Verifier");
        
        this.RuleFor(x => x.UserId).NotEmpty()
            .WithMessage(this.GetType().Name + "_" + "IsEmpty" + "_" + "UserId");
        this.RuleFor(x => x.UserId).NotEqual(Guid.Empty)
            .WithMessage(this.GetType().Name + "_" + "IsGuidEmpty" + "_" + "UserId");  
       
    }
}