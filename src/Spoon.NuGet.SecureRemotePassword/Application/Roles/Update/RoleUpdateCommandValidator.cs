namespace Spoon.NuGet.SecureRemotePassword.Application.Roles.Update;

using FluentValidation;

/// <summary>
///     Class ProductCreateQueryValidator. This class cannot be inherited.
/// </summary>
public sealed class RoleUpdateCommandValidator : AbstractValidator<RoleUpdateCommand>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="RoleUpdateCommandValidator" /> class.
    /// </summary>
    public RoleUpdateCommandValidator()
    {
        /*
        this.RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage(this.GetType().Name + "_" + "IsEmpty" + "_" + "UserId");

        this.RuleFor(x => x.Salt)
            .NotEmpty()
            .WithMessage(this.GetType().Name + "_" + "IsEmpty" + "_" + "Salt");

        this.RuleFor(x => x.Verifier)
            .NotEmpty()
            .WithMessage(this.GetType().Name + "_" + "IsEmpty" + "_" + "Verifier");
            */
    }
}