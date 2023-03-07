namespace Spoon.NuGet.SecureRemotePassword.Application.Me.Delete.Soft;

using FluentValidation;

/// <summary>
///     Class ProductCreateQueryValidator. This class cannot be inherited.
/// </summary>
public sealed class MeDeleteSoftCommandValidator : AbstractValidator<MeDeleteSoftCommand>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="MeDeleteSoftCommandValidator" /> class.
    /// </summary>
    public MeDeleteSoftCommandValidator()
    {
        this.RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage(this.GetType().Name + "_" + "IsEmpty" + "_" + "UserId")
            .NotEqual(Guid.Empty)
            .WithMessage(this.GetType().Name + "_" + "IsGuidEmpty" + "_" + "UserId");
        
        this.RuleFor(x => x.EmailId)
            .NotEmpty()
            .WithMessage(this.GetType().Name + "_" + "IsEmpty" + "_" + "EmailId")
            .NotEqual(Guid.Empty)
            .WithMessage(this.GetType().Name + "_" + "IsGuidEmpty" + "_" + "EmailId");

    }
}