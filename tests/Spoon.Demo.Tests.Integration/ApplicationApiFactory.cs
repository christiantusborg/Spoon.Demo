namespace Spoon.Demo.Tests.Integration;

using Application;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

public class ApplicationApiFactory : WebApplicationFactory<IApplicationAssemblyMarker>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(collection =>
        {
           collection.RemoveAll(typeof(IDbConnectionFactory));
           collection.AddSingleton<IDbConnectionFactory>(_ =>
             new SqliteConnectionFactory("DataSource=file:inmem?mode=memory&cache=shared"));
           this.GetTestAssemblies();


        });
    }
}
//IApplicationAssemblyMarker