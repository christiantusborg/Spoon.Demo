namespace Spoon.Demo.Root.Swagger;

using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

/// <summary>
/// 
/// </summary>
public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
{
   // private readonly IApiVersionDescriptionProvider _provider;
    private readonly IHostEnvironment _environment;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="provider"></param>
    /// <param name="environment"></param>
    public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider, IHostEnvironment environment)
    {
     //   this._provider = provider;
        this._environment = environment;
    }

    /// <inheritdoc  />
    public void Configure(SwaggerGenOptions options)
    {
        /*
        foreach (var description in this._provider.ApiVersionDescriptions)
        {
            options.SwaggerDoc(
                description.GroupName,
                new OpenApiInfo
                {
                    Title = this._environment.ApplicationName,
           //         Version = description.ApiVersion.ToString(),
                });
        }
        */
        options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "Please provide a valid token",
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            BearerFormat = "JWT",
            Scheme = "Bearer"
        });
        
        options.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                Array.Empty<string>()
            }
        });
    }
}
