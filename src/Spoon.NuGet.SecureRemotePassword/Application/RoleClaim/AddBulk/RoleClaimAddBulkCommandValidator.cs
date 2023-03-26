namespace Spoon.NuGet.SecureRemotePassword.Application.RoleClaim.AddBulk;

using FluentValidation;

/// <summary>
///     Class ProductCreateQueryValidator. This class cannot be inherited.
/// </summary>
public sealed class RoleClaimAddBulkCommandValidator : AbstractValidator<RoleClaimAddBulkCommand>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="RoleClaimAddBulkCommandValidator" /> class.
    /// </summary>
    public RoleClaimAddBulkCommandValidator()
    {
        this.RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage(this.GetType().Name + "_" + "IsEmpty" + "_" + "UserId")
            .NotEqual(Guid.Empty)
            .WithMessage(this.GetType().Name + "_" + "IsGuidEmpty" + "_" + "UserId");
    }
}