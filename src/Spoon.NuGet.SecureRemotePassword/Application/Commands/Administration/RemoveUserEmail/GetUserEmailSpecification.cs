namespace Spoon.NuGet.SecureRemotePassword.Application.Commands.Administration.RemoveUserEmail;

using Core.Domain;
using Domain.Entities;

/// <summary>
///     Class ProductCreateQueryValidator. This class cannot be inherited.
/// </summary>
public class GetUserEmailSpecification : Specification<UserEmail>
{
    /// <inheritdoc />
    public GetUserEmailSpecification(Guid userId, Guid EmailId)
    {
        var filters = new List<Filter>
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
                Value = EmailId,
                PropertyName = "EmailId",
            },
        };

        this.AddFilters(filters);


        this.AddSkip(0);

        this.AddTake(1);
    }
}