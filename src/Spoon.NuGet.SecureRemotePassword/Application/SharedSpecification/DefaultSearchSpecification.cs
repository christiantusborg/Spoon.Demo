namespace Spoon.NuGet.SecureRemotePassword.Application.SharedSpecification;

using Core.Domain;
using Domain.Entities;

public class DefaultSearchSpecification<TEntity> : Specification<TEntity> where TEntity : Entity
{
    /// <inheritdoc />
    public DefaultSearchSpecification() 
    {

        this.AddSkip(0);

        this.AddTake(9999);
    }
}