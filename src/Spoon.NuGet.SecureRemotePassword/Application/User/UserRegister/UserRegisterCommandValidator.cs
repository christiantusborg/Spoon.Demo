namespace Spoon.NuGet.SecureRemotePassword.Application.User.UserRegister;

using FluentValidation;

/// <summary>
///     Class ProductCreateQueryValidator. This class cannot be inherited.
/// </summary>
public sealed class UserRegisterCommandValidator : AbstractValidator<UserRegisterCommand>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="UserRegisterCommandValidator" /> class.
    /// </summary>
    public UserRegisterCommandValidator()
    {
    }
}