namespace Spoon.NuGet.SecureRemotePassword.Application.Me.Email.SetAsPrimaryEmail;

using FluentValidation;

/// <summary>
///     Class ProductCreateQueryValidator. This class cannot be inherited.
/// </summary>
public sealed class MeEmailSetAsPrimaryCommandValidator : AbstractValidator<MeEmailSetAsPrimaryCommand>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="MeEmailSetAsPrimaryCommandValidator" /> class.
    /// </summary>
    public MeEmailSetAsPrimaryCommandValidator()
    {
        this.RuleFor(x => x.EmailId)
            .NotEmpty()
            .WithMessage(this.GetType().Name + "_" + "IsEmpty" + "_" + "EmailId")
            .NotEqual(Guid.Empty)
            .WithMessage(this.GetType().Name + "_" + "IsGuidEmpty" + "_" + "EmailId");
        
        this.RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage(this.GetType().Name + "_" + "IsEmpty" + "_" + "UserId")
            .NotEqual(Guid.Empty)
            .WithMessage(this.GetType().Name + "_" + "IsGuidEmpty" + "_" + "UserId");
    }
}