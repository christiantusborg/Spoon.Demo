namespace Spoon.NuGet.SecureRemotePassword.Application.Me.Email.GetAll;

using FluentValidation;

/// <summary>
///     Class ProductCreateQueryValidator. This class cannot be inherited.
/// </summary>
public sealed class MeEmailGetAllCommandValidator : AbstractValidator<MeEmailGetAllCommand>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="MeEmailGetAllCommandValidator" /> class.
    /// </summary>
    public MeEmailGetAllCommandValidator()
    {
        this.RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage(this.GetType().Name + "_" + "IsEmpty" + "_" + "UserId")
            .NotEqual(Guid.Empty)
            .WithMessage(this.GetType().Name + "_" + "IsGuidEmpty" + "_" + "UserId");
    }
}