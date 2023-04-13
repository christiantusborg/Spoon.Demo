namespace Spoon.NuGet.SecureRemotePassword.Application.Roles.GetAll;

using Core.Validation;
using FluentValidation;

/// <summary>
///     Class ProductCreateQueryValidator. This class cannot be inherited.
/// </summary>
public sealed class RoleGetAllCommandValidator : BaseValidator<RoleGetAllCommand>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="RoleGetAllCommandValidator" /> class.
    /// </summary>
    public RoleGetAllCommandValidator()
    {
    }
}