namespace Spoon.NuGet.SecureRemotePassword.Application.Commands.Administration.GetUser;

using Core.Domain;
using Domain.Entities;

/// <inheritdoc />
public class GetUserSpecification : Specification<User>
{
    /// <inheritdoc />
    public GetUserSpecification(Guid userId)
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


        this.AddInclude(x => x.Claims);
        this.AddInclude(x => x.Roles);
        //TODO : Add this to the specification (ThenInclude)    
        //.ThenInclude(x => x.Claims);

        this.AddSkip(0);

        this.AddTake(1);
    }
}