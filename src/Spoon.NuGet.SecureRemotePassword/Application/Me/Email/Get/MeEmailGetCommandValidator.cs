namespace Spoon.NuGet.SecureRemotePassword.Application.Me.Email.Get;

using FluentValidation;

/// <summary>
///     Class ProductCreateQueryValidator. This class cannot be inherited.
/// </summary>
public sealed class MeEmailGetCommandValidator : AbstractValidator<MeEmailGetCommand>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="MeEmailGetCommandValidator" /> class.
    /// </summary>
    public MeEmailGetCommandValidator()
    {
        this.RuleFor(x => x.EmailId)
            .NotEmpty()
            .WithMessage(this.GetType().Name + "_" + "IsEmpty" + "_" + "EmailId")
            .NotEqual(Guid.Empty)
            .WithMessage(this.GetType().Name + "_" + "IsGuidEmpty" + "_" + "EmailId");
    }
}