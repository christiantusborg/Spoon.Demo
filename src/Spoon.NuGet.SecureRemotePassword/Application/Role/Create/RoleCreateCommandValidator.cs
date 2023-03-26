namespace Spoon.NuGet.SecureRemotePassword.Application.Role.Create;

using FluentValidation;

/// <summary>
///     Class ProductCreateQueryValidator. This class cannot be inherited.
/// </summary>
public sealed class RoleCreateCommandValidator : AbstractValidator<RoleCreateCommand>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="RoleCreateCommandValidator" /> class.
    /// </summary>
    public RoleCreateCommandValidator()
    {
        this.RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage(this.GetType().Name + "_" + "IsEmpty" + "_" + "UserId");
    }
}