namespace Spoon.NuGet.SecureRemotePassword.Application.Role.Get;

using FluentValidation;

/// <summary>
///     Class ProductCreateQueryValidator. This class cannot be inherited.
/// </summary>
public sealed class RoleGetCommandValidator : AbstractValidator<RoleGetCommand>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="RoleGetCommandValidator" /> class.
    /// </summary>
    public RoleGetCommandValidator()
    {
        this.RuleFor(x => x.RoleId)
            .NotEmpty()
            .WithMessage(this.GetType().Name + "_" + "IsEmpty" + "_" + "RoleId");
    }
}