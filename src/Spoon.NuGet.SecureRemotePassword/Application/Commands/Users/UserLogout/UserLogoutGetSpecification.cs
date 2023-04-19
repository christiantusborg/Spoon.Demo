namespace Spoon.NuGet.SecureRemotePassword.Application.Commands.Users.UserLogout;

using Core.Domain;
using Domain.Entities;

/// <summary>
///     Class SessionGetSpecification. This class cannot be inherited.
/// </summary>
public class UserLogoutGetSpecification : Specification<Session>
{
    /// <summary>
    ///     Class SessionGetSpecification. This class cannot be inherited.
    /// </summary>
    public UserLogoutGetSpecification(Guid userId, Guid sessionId)
    {
        this.AddFilters(new List<Filter>
        {
            new()
            {
                Operation = Operation.Equals,
                Value = userId,
                PropertyName = "UserId",
            },
            new()
            {
                Operation = Operation.Equals,
                Value = sessionId,
                PropertyName = "SessionId",
            },
        });
        this.AddTake(1);
    }
}