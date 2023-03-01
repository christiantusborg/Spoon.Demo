namespace Spoon.Demo.Presentation.Api.Contracts;

using System.Text.Json;
using System.Text.Json.Serialization;
using NuGet.Core.Domain;

public class SearchRequest
{
    public List<Filter> Filters { get; set; }

    public static bool TryParse(string? value, out SearchRequest? filters)
    {

        try
        {
            var filter =  JsonSerializer.Deserialize<List<Filter>>(value);
            filters = new SearchRequest
            {
                Filters = filter,
            };
            return true;
        }
        catch (Exception e)
        {
            filters = null;
            return false;
        }
        
        
    }
}