namespace Spoon.NuGet.SecureRemotePassword.Application.Commands.Users.UserLogoutAll;

using Core.Domain;
using Domain.Entities;

/// <summary>
///     Class SessionGetSpecification. This class cannot be inherited.
/// </summary>
public class UserLogoutAllGetSpecification : Specification<Session>
{
    /// <summary>
    ///     Class SessionGetSpecification. This class cannot be inherited.
    /// </summary>
    public UserLogoutAllGetSpecification(Guid userId)
    {
        this.AddFilters(new List<Filter>
        {
            new()
            {
                Operation = Operation.Equals,
                Value = userId,
                PropertyName = "UserId",
            },
        });
        this.AddTake(int.MaxValue);
    }
}