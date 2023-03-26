namespace Spoon.NuGet.SecureRemotePassword.Application.UserRole.AddBulk;

using FluentValidation;

/// <summary>
///     Class ProductCreateQueryValidator. This class cannot be inherited.
/// </summary>
public sealed class UserRoleAddBulkCommandValidator : AbstractValidator<UserRoleAddBulkCommand>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="UserRoleAddBulkCommandValidator" /> class.
    /// </summary>
    public UserRoleAddBulkCommandValidator()
    {
        this.RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage(this.GetType().Name + "_" + "IsEmpty" + "_" + "UserId")
            .NotEqual(Guid.Empty)
            .WithMessage(this.GetType().Name + "_" + "IsGuidEmpty" + "_" + "UserId");
    }
}