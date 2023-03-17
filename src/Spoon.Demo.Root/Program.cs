using System.Text;
using App.Metrics;
using App.Metrics.Counter;
using Asp.Versioning;
using Carter;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Spoon.Demo.Application;
using Spoon.Demo.Application.Health;
using Spoon.Demo.Application.V1.Products.Queries.Get;
using Spoon.Demo.Domain.Repositories;
using Spoon.Demo.Persistence.Repositories;
using Spoon.Demo.Presentation.Api;
using Spoon.Demo.Presentation.Api.Endpoints;
using Spoon.Demo.Presentation.Api.Endpoints.V1.Products.Extensions;

using Spoon.Demo.Presentation.Api.Swagger;
using Spoon.NuGet.Core;
using Spoon.NuGet.Mediator.PipelineBehaviors.AuditLog;
using Spoon.NuGet.Mediator.PipelineBehaviors.Permission;
using Spoon.NuGet.Mediator.PipelineBehaviors.Validation;
using Spoon.NuGet.SecureRemotePassword.Endpoints.Administration.Extensions;
using Spoon.NuGet.SecureRemotePassword.Endpoints.Me;
using Spoon.NuGet.SecureRemotePassword.Endpoints.User.Extensions;
using Swashbuckle.AspNetCore.SwaggerGen;

var builder = WebApplication.CreateBuilder(args);

var config = builder.Configuration;
/*
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.TokenValidationParameters = new TokenValidationParameters
    {
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(config["Jwt:Key"]!)),
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,
        ValidIssuer = config["Jwt:Issuer"],
        ValidAudience = config["Jwt:Audience"],
        ValidateIssuer = true,
        ValidateAudience = true
    };
});
*/
/*
builder.Services.AddAuthorization(x =>
{
    // x.AddPolicy(AuthConstants.AdminUserPolicyName, 
    //     p => p.RequireClaim(AuthConstants.AdminUserClaimName, "true"));

    
    //x.AddPolicy(AuthConstants.AdminUserPolicyName,
    //    p => p.AddRequirements(new AdminAuthRequirement(config["ApiKey"]!)));
    
    //x.AddPolicy(AuthConstants.TrustedMemberPolicyName,
    //    p => p.RequireAssertion(c => 
    //        c.User.HasClaim(m => m is { Type: AuthConstants.AdminUserClaimName, Value: "true" }) || 
    //        c.User.HasClaim(m => m is { Type: AuthConstants.TrustedMemberClaimName, Value: "true" })));
});
*/

//builder.Services.AddScoped<ApiKeyAuthFilter>();



builder.Services.AddApiVersioning(x =>
{
    x.DefaultApiVersion = new ApiVersion(1.0);
    x.AssumeDefaultVersionWhenUnspecified = true;
    x.ReportApiVersions = true;
    x.ApiVersionReader = new MediaTypeApiVersionReader("api-version");
}).AddApiExplorer();

builder.Services.AddOutputCache(x =>
{
    x.AddBasePolicy(c => c.Cache());
    x.AddCacheOptionsProducts();
});


builder.Host
    .ConfigureMetricsWithDefaults(
        builder =>
        {
            builder.OutputMetrics.AsPlainText();
            //builder.Report.ToTextFile(@"C:\metrics.txt", TimeSpan.FromSeconds(20));
        })
    .UseMetricsEndpoints();


builder.Services.AddEndpointsApiExplorer();

//AddOutputCache


builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
builder.Services.AddSwaggerGen(x =>
{
    x.OperationFilter<SwaggerDefaultValues>();
    x.EnableAnnotations();
});



//builder.Services.AddScoped<MetricActionFilterCounterExtensions>();
//var connectionString = "Data Source=Database.db";
//builder.Services.AddSqlite<GetingeDb>(connectionString);


builder.Services.AddMediatR(typeof(ProductGetQuery));


builder.Services.AddDbContext<DbContext>(optionsBuilder =>
    {
        var connectionString = builder.Configuration.GetConnectionString("DatabaseWrite");
        optionsBuilder.UseSqlite(connectionString);
    }
);

/*
builder.Services.AddDbContext<ReadOnlyContext>(optionsBuilder =>
    {
        var connectionString = builder.Configuration.GetConnectionString("DatabaseReadOnly");
        optionsBuilder.UseSqlite(connectionString);
    }
);
*/


builder.Services.AddApplication();

builder.Services.AddMetrics();
    
builder.Services.AddMetricsEndpoints();
builder.Services.AddMemoryCache();


//.AddEndpointFilter<ValidationFilter>();

var app = builder.Build();
app.UseMetricsAllEndpoints();

app.CreateApiVersionSet();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(x =>
    {
        foreach (var description in app.DescribeApiVersions())
        {
            x.SwaggerEndpoint( $"/swagger/{description.GroupName}/swagger.json",
                description.GroupName);
        }
    });
}

//app.MapHealthChecks("_health");

app.UseHttpsRedirection();

//app.UseAuthentication();
//app.UseAuthorization();
app.UseOutputCache();
app.MapAdministrationUserEndpoints();
app.MapMeEndpoints();
//app.MapUserEndpoints();
app.MapEndpoints();

//app.UseOutputCache();
//EndpointFiltersMetricCounter
//var x = app.MapGroup("").AddEndpointFilter<ValidationFilter2>();
//x.MapCarter();

app.Run();
//dotnet ef dbcontext scaffold "D:\Git\Getinge\Getinge.Bootstrap" Microsoft.EntityFrameworkCore.Sqlite --output-dir Models --force

//Scaffold-DbContext "D:\Git\Getinge\Getinge.Bootstrap" Microsoft.EntityFrameworkCore.Sqlite


//dotnet ef dbcontext scaffold "mysql.epro-network.org;Uid=getinge;Pwd=!Getinge;Database=getinge" Pomelo.EntityFrameworkCore.MySql --output-dir Models --force


//Server: mysql.epro-network.org

/// <summary>
/// </summary>
public class ValidationFilter2 : IEndpointFilter
{
    /// <summary>
    ///     The metrics.
    /// </summary>
    private readonly IMetrics _metrics;

    /// <summary>
    ///     The configuration.
    /// </summary>
    private readonly IConfiguration _configuration;

    /// <summary>
    /// </summary>
    /// <param name="metrics">The metrics.</param>
    /// <param name="configuration">The configuration.</param>
    public ValidationFilter2(IMetrics metrics, IConfiguration configuration)
    {
        this._metrics = metrics;
        this._configuration = configuration;
    }


    /// <summary>
    /// </summary>
    /// <param name="context"></param>
    /// <param name="next"></param>
    /// <returns></returns>
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {

        var endpointName = "";
        
        var endpointFeature = context.HttpContext.Features.Get<IEndpointFeature>();
        if (endpointFeature?.Endpoint is RouteEndpoint re &&  re.RoutePattern.RawText is not null)
        {
            var displayNameReplace = re.RoutePattern.RawText
                .Replace("{", "")
                .Replace("/", "_")
                .Replace(":", "_")
                .Replace("}", "")
                .ToLower();
            
            if (displayNameReplace[0] == '_')
            {
                endpointName = displayNameReplace[1..];
            }
        }

        var customersCounter = new CounterOptions
        {
            Name = "CounterOptions",
            Context = "IActionFilter",
            Tags = new MetricTags(new[] { "EndpointName" }, new[] { endpointName }),
            MeasurementUnit = App.Metrics.Unit.Calls,
        };
        
        // Otherwise invoke the next filter in the pipeline
        return await next.Invoke(context);
    }
}