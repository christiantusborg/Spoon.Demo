namespace Spoon.NuGet.SecureRemotePassword.Application.Me.VerifyChallenge;

using FluentValidation;

/// <summary>
///     Class ProductCreateQueryValidator. This class cannot be inherited.
/// </summary>
public sealed class MeVerifyChallengeGetCommandValidator : AbstractValidator<MeVerifyChallengeGetCommand>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="MeVerifyChallengeGetCommandValidator" /> class.
    /// </summary>
    public MeVerifyChallengeGetCommandValidator()
    {
        this.RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage(this.GetType().Name + "_" + "IsEmpty" + "_" + "UserId")
            .NotEqual(Guid.Empty)
            .WithMessage(this.GetType().Name + "_" + "IsGuidEmpty" + "_" + "UserId");
    }
}