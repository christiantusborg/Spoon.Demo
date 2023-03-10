namespace Spoon.NuGet.SecureRemotePassword.Application.User.ConfirmEmail;

using FluentValidation;

/// <summary>
///     Class ProductCreateQueryValidator. This class cannot be inherited.
/// </summary>
public sealed class UserConfirmEmailCommandValidator : AbstractValidator<UserConfirmEmailCommand>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="UserConfirmEmailCommandValidator" /> class.
    /// </summary>
    public UserConfirmEmailCommandValidator()
    {
        this.RuleFor(x => x.ConfirmCode)
            .NotEmpty()
            .WithMessage(this.GetType().Name + "_" + "IsEmpty" + "_" + "ConfirmCode");
    }
}