namespace Spoon.NuGet.SecureRemotePassword.Application.UserClaim.AddBulk;

using FluentValidation;

/// <summary>
///     Class ProductCreateQueryValidator. This class cannot be inherited.
/// </summary>
public sealed class UserClaimAddBulkCommandValidator : AbstractValidator<UserClaimAddBulkCommand>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="UserClaimAddBulkCommandValidator" /> class.
    /// </summary>
    public UserClaimAddBulkCommandValidator()
    {
        this.RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage(this.GetType().Name + "_" + "IsEmpty" + "_" + "UserId")
            .NotEqual(Guid.Empty)
            .WithMessage(this.GetType().Name + "_" + "IsGuidEmpty" + "_" + "UserId");
    }
}