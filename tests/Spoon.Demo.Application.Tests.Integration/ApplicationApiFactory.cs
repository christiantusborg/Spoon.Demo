namespace Spoon.Demo.Application.Tests.Integration;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

public class ApplicationApiFactory : WebApplicationFactory<IApiMarker>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(collection =>
        {
            collection.RemoveAll(typeof(IDbConnectionFactory));
            ServiceCollectionServiceExtensions.AddSingleton<IDbConnectionFactory>(collection, _ =>
                new SqliteConnectionFactory("DataSource=file:inmem?mode=memory&cache=shared"));

        });
    }
}
