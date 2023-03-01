namespace Spoon.Demo.Presentation.Api;

using Asp.Versioning.Builder;
using Asp.Versioning.Conventions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

/// <summary>
/// 
/// </summary>
public static class ApiVersioning
{
    /// <inheritdoc cref="ApiVersioning" />
    public static ApiVersionSet? VersionSet { get; private set; }

    /// <inheritdoc cref="ApiVersioning" />
    public static IEndpointRouteBuilder CreateApiVersionSet(this IEndpointRouteBuilder app)
    {
        VersionSet = app.NewApiVersionSet()
            .HasApiVersion(1.0)
            .HasApiVersion(2.0)
            .ReportApiVersions()
            .Build();

        return app;
    }
}