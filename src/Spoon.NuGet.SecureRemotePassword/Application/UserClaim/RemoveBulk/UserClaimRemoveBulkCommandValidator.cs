namespace Spoon.NuGet.SecureRemotePassword.Application.UserClaim.RemoveBulk;

using FluentValidation;

/// <summary>
///     Class ProductCreateQueryValidator. This class cannot be inherited.
/// </summary>
public sealed class UserClaimRemoveBulkCommandValidator : AbstractValidator<UserClaimRemoveBulkCommand>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="UserClaimRemoveBulkCommandValidator" /> class.
    /// </summary>
    public UserClaimRemoveBulkCommandValidator()
    {
        this.RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage(this.GetType().Name + "_" + "IsEmpty" + "_" + "UserId")
            .NotEqual(Guid.Empty)
            .WithMessage(this.GetType().Name + "_" + "IsGuidEmpty" + "_" + "UserId");
    }
}