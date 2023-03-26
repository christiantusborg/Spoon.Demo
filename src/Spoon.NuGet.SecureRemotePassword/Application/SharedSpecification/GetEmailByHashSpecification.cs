namespace Spoon.NuGet.SecureRemotePassword.Application.SharedSpecification
{
    using Spoon.NuGet.Core.Domain;
    using Spoon.NuGet.SecureRemotePassword.Domain.Entities;

    /// <inheritdoc />
    public class GetEmailByHashSpecification : Specification<UserEmail>
    {
        /// <inheritdoc />
        public GetEmailByHashSpecification(string emailAddressHash)
        {
            var filters = new List<Filter>
            {
                new Filter
                {
                    Operation = Operation.Equals,
                    Value = emailAddressHash,
                    PropertyName = "EmailAddressHash",
                }
            };
            this.AddFilters(filters);


            this.AddSkip(0);
            
            this.AddTake(1);
        }
    }
}