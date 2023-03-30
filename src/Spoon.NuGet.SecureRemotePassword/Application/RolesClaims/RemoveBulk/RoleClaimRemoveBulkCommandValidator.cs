namespace Spoon.NuGet.SecureRemotePassword.Application.RolesClaims.RemoveBulk;

using FluentValidation;

/// <summary>
///     Class ProductCreateQueryValidator. This class cannot be inherited.
/// </summary>
public sealed class RoleClaimRemoveBulkCommandValidator : AbstractValidator<RoleClaimRemoveBulkCommand>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="RoleClaimRemoveBulkCommandValidator" /> class.
    /// </summary>
    public RoleClaimRemoveBulkCommandValidator()
    {
        this.RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage(this.GetType().Name + "_" + "IsEmpty" + "_" + "UserId")
            .NotEqual(Guid.Empty)
            .WithMessage(this.GetType().Name + "_" + "IsGuidEmpty" + "_" + "UserId");
    }
}