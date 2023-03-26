namespace Spoon.NuGet.SecureRemotePassword.Application.UserRole.RemoveBulk;

using FluentValidation;

/// <summary>
///     Class ProductCreateQueryValidator. This class cannot be inherited.
/// </summary>
public sealed class UserRoleRemoveBulkCommandValidator : AbstractValidator<UserRoleRemoveBulkCommand>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="UserRoleRemoveBulkCommandValidator" /> class.
    /// </summary>
    public UserRoleRemoveBulkCommandValidator()
    {
        this.RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage(this.GetType().Name + "_" + "IsEmpty" + "_" + "UserId")
            .NotEqual(Guid.Empty)
            .WithMessage(this.GetType().Name + "_" + "IsGuidEmpty" + "_" + "UserId");
    }
}