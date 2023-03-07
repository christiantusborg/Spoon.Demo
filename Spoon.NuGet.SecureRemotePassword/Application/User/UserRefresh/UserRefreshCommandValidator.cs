namespace Spoon.NuGet.SecureRemotePassword.Application.User.UserRefresh;

using FluentValidation;

/// <summary>
///     Class ProductCreateQueryValidator. This class cannot be inherited.
/// </summary>
public sealed class UserRefreshCommandValidator : AbstractValidator<UserRefreshCommand>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="UserRefreshCommandValidator" /> class.
    /// </summary>
    public UserRefreshCommandValidator()
    {
    }
}