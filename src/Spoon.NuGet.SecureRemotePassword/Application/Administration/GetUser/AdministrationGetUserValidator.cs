namespace Spoon.NuGet.SecureRemotePassword.Application.Administration.GetUser;

using FluentValidation;

/// <summary>
///     Class ProductCreateQueryValidator. This class cannot be inherited.
/// </summary>
public sealed class AdministrationGetUserValidator : AbstractValidator<AdministrationGetUserCommand>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="AdministrationGetUserValidator" /> class.
    /// </summary>
    public AdministrationGetUserValidator()
    {
        this.RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage(this.GetType().Name + "_" + "IsEmpty" + "_" + "UserId")
            .NotEqual(Guid.Empty)
            .WithMessage(this.GetType().Name + "_" + "IsGuidEmpty" + "_" + "UserId");
    }
}