namespace Spoon.NuGet.SecureRemotePassword.Application.Commands.Administration.SetUserEmailAsPrimary;

using Core.Domain;
using Domain.Entities;

/// <inheritdoc />
public class GetSetUserEmailAsPrimarySpecification : Specification<UserEmail>
{
    /// <inheritdoc />
    public GetSetUserEmailAsPrimarySpecification(Guid userId)
    {
        var filters = new List<Filter>
        {
            new()
            {
                Operation = Operation.Equals,
                Value = userId,
                PropertyName = "UserId",
            },
        };

        this.AddFilters(filters);


        this.AddSkip(0);

        this.AddTake(9999);
    }
}