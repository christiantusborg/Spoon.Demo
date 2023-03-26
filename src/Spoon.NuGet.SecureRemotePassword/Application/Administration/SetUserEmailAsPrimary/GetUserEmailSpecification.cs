namespace Spoon.NuGet.SecureRemotePassword.Application.Administration.SetUserEmailAsPrimary
{
    using Spoon.NuGet.Core.Domain;
    using Spoon.NuGet.SecureRemotePassword.Domain.Entities;

    /// <inheritdoc />
    public class GetSetUserEmailAsPrimarySpecification : Specification<UserEmail>
    {
        /// <inheritdoc />
        public GetSetUserEmailAsPrimarySpecification(Guid userId)
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
    }