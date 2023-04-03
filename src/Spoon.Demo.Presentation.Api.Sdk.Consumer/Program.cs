
using Microsoft.Extensions.DependencyInjection;
using Refit;
using Spoon.Demo.Presentation.Api.Contracts.Products.Requests;
using Spoon.Demo.Presentation.Api.Sdk;
using Spoon.Demo.Presentation.Api.Sdk.Consumer;
using Spoon.NuGet.Core.Domain;


var services = new ServiceCollection();
/*
services.AddHttpClient()
    .AddSingleton<AuthTokenProvider>()
    .AddRefitClient<IProductApi>(s => new RefitSettings
    {
        AuthorizationHeaderValueGetter = async () => await s.GetRequiredService<AuthTokenProvider>().GetTokenAsync()
    })
    .ConfigureHttpClient(x =>
        x.BaseAddress = new Uri("https://localhost:5001"));

var provider = services.BuildServiceProvider();

var productApi = provider.GetRequiredService<IProductApi>();
*


var product = await productApi.GetProductAsync("nick-the-greek-2022");

var newProduct = await productApi.CreateProductAsync(new ProductCreateRequest
{
    ProductId = Guid.NewGuid(),
});

await productApi.UpdateProductAsync(newProduct.ProductId, new ProductUpdateRequest()
{
    ProductId = newProduct.ProductId,
});

await productApi.DeleteProductAsync(newProduct.ProductId);

await productApi.DeletePermanentProductAsync(newProduct.ProductId);

var request = new ProductSearchRequest
{
    Filters = new List<Filter>(),
    Page = 1,
    PageLength = 10,
};
*/
//Spoon.Demo.Presentation.Api.Contracts
