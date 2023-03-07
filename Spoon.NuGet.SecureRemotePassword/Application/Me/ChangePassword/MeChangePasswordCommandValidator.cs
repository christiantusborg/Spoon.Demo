namespace Spoon.NuGet.SecureRemotePassword.Application.Me.ChangePassword;

using FluentValidation;

/// <summary>
/// Class ProductCreateQueryValidator. This class cannot be inherited.
/// </summary>
public sealed class MeChangePasswordCommandValidator : AbstractValidator<MeChangePasswordCommand>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MeChangePasswordCommandValidator"/> class.
    /// </summary>
    public MeChangePasswordCommandValidator()
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