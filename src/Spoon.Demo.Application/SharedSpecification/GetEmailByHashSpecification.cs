namespace Spoon.Demo.Application.SharedSpecification;

using Domain.Entities;
using Spoon.NuGet.Core.Domain;
using Spoon.NuGet.SecureRemotePassword.Domain.Entities;

/// <inheritdoc />
public class GetCategoriesByNameSpecification : Specification<Category>
{
    /// <inheritdoc />
    public GetCategoriesByNameSpecification(string name)
    {
        var filters = new List<Filter>
        {
            new()
            {
                Operation = Operation.Equals,
                Value = name,
                PropertyName = "Name",
            },
        };
        this.AddFilters(filters);


        this.AddSkip(0);

        this.AddTake(1);
    }
}