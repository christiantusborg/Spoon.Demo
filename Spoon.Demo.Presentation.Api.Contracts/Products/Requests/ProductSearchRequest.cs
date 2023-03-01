namespace Spoon.Demo.Presentation.Api.Contracts.Products.Requests;

using System.ComponentModel;
using System.Reflection;
using System.Web;
using Microsoft.AspNetCore.Http;
using Spoon.NuGet.Core.Presentation;

/// <summary>
///     Class ProductGetAllRequest.
/// </summary>
public class ProductSearchRequest : ApiBaseQueryWithSearchAndPagination
{
    /// <summary>
    ///     Gets or sets the product identifier.
    /// </summary>
    /// <value>The product identifier.</value>
    public Guid ProductId { get; set; }

    /// <summary>
    /// </summary>
    /// <param name="value"></param>
    /// <param name="provider"></param>
    /// <param name="objResult"></param>
    /// <returns></returns>
    public static bool TryParse(string? value, IFormatProvider? provider, out ProductSearchRequest? objResult)
    {
        objResult = new ProductSearchRequest
        {
            Page = 1,
            PageLength = 10,
        };
        //}
        //   objResult = GetFromQueryString<SearchRequest>(value, objResult);
        return true;
    }

    /// <summary>
    /// </summary>
    /// <param name="queryString"></param>
    /// <param name="obj"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T GetFromQueryString<T>(string queryString, T obj) where T : new()
    {
        var query = HttpUtility.ParseQueryString(queryString);
        if (obj == null)
        {
            obj = new T();
        }

        var properties = typeof(T).GetProperties(); // to get all properties from Class(Object)  
        foreach (var property in properties)
        {
            var valueAsString = query.AllKeys.Where(a => a == property.Name);
            if (valueAsString.Any())
            {
                // object value = Parse(property.PropertyType, query[property.Name]); // parse data types  
                // (value == null)
                //    continue;                     property.SetValue(obj, value, null); //set values to properties.  
            }
        }

        return obj;
    }

    /// <summary>
    /// </summary>
    /// <param name="context"></param>
    /// <param name="parameter"></param>
    /// <returns></returns>
    public static ValueTask<ProductSearchRequest?> BindAsync(HttpContext context,
        ParameterInfo parameter)
    {
        //const string sortByKey = "sortBy";
        //const string sortDirectionKey = "sortDir";
        //const string currentPageKey = "page";             //Enum.TryParse<SortDirection>(context.Request.Query[sortDirectionKey],
        //                             ignoreCase: true, out var sortDirection);
        //int.TryParse(context.Request.Query[currentPageKey], out var page);
        //page = page == 0 ? 1 : page;
        //var result = new PagingData
        //{
        // SortBy = context.Request.Query[sortByKey],
        // SortDirection = sortDirection,
        // CurrentPage = page
        //};
        var objResult = new ProductSearchRequest
        {
            Page = 1,
            PageLength = 10,
        };
        //}
        //   objResult = GetFromQueryString<ProductSearchRequest>(context.Request.QueryString.Value, objResult);
        return ValueTask.FromResult<ProductSearchRequest?>(objResult);
    }

    /// <summary>
    /// </summary>
    /// <param name="dataType"></param>
    /// <param name="ValueToConvert"></param>
    /// <returns></returns>
    public static object Parse(Type dataType, string ValueToConvert)
    {
        var obj = TypeDescriptor.GetConverter(dataType);
        //object value = obj.ConvertFromString(null, CultureInfo.InvariantCulture, ValueToConvert);
        return string.Empty;
    }
}