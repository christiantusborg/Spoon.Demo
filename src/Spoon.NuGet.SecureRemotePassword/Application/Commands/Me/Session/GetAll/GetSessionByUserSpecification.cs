namespace Spoon.NuGet.SecureRemotePassword.Application.Commands.Me.Session.GetAll;

using Core.Domain;
using Domain.Entities;

public class GetByUserSpecification : Specification<Session>
{
    /// <inheritdoc />
    public GetByUserSpecification(Guid userId)
    {
        var filters = new List<Filter>
        {
            new Filter
            {
                Operation = Operation.Equals,
                Value = userId,
                PropertyName = "UserId",
            }
        };
            
        this.AddFilters(filters);

        this.AddSkip(0);

        this.AddTake(9999);
    }
}