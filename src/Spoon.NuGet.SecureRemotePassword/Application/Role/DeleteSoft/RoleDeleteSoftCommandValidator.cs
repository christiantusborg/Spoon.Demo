namespace Spoon.NuGet.SecureRemotePassword.Application.Role.DeleteSoft;

using FluentValidation;

/// <summary>
///     Class ProductCreateQueryValidator. This class cannot be inherited.
/// </summary>
public sealed class RoleDeleteSoftCommandValidator : AbstractValidator<RoleDeleteSoftCommand>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="RoleDeleteSoftCommandValidator" /> class.
    /// </summary>
    public RoleDeleteSoftCommandValidator()
    {
        this.RuleFor(x => x.RoleId)
            .NotEmpty()
            .WithMessage(this.GetType().Name + "_" + "IsEmpty" + "_" + "RoleId");
    }
}