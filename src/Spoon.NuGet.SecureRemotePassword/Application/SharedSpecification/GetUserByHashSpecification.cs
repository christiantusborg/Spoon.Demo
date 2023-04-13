namespace Spoon.NuGet.SecureRemotePassword.Application.SharedSpecification
{
    using Spoon.NuGet.Core.Domain;
    using Spoon.NuGet.SecureRemotePassword.Domain.Entities;

    /// <inheritdoc />
    public class GetUserByHashSpecification : Specification<User>
    {
        /// <inheritdoc />
        public GetUserByHashSpecification(string usernameHash)
        {
            var filters = new List<Filter>
            {
                new Filter
                {
                    Operation = Operation.Equals,
                    Value = usernameHash,
                    PropertyName = "UsernameHash",
                }
            };
            this.AddFilters(filters);


            this.AddSkip(0);
            
            this.AddTake(1);
        }
    }
}