namespace Spoon.Demo.Application.Health;

using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Logging;

public class DatabaseHealthCheck: IHealthCheck
{
    //TODO Add real code for Database HealthCheck
    public const string Name = "Database";
    
   // private readonly IDbConnectionFactory _dbConnectionFactory;
    private readonly ILogger<DatabaseHealthCheck> _logger;

    public DatabaseHealthCheck(ILogger<DatabaseHealthCheck> logger)
    //public DatabaseHealthCheck(IDbConnectionFactory dbConnectionFactory, ILogger<DatabaseHealthCheck> logger)
    {
        this._logger = logger;
    }

    public async Task<HealthCheckResult> CheckHealthAsync(
        HealthCheckContext context, CancellationToken cancellationToken = new())
    {
        try
        {
            //_ = await _dbConnectionFactory.CreateConnectionAsync(cancellationToken);
            return HealthCheckResult.Healthy();
        }
        catch (Exception e)
        {
             
            const string errorMessage = ApplicationHealthCheckMessages.DatabaseErrorMessage;
            this._logger.LogError(errorMessage, e);
            return HealthCheckResult.Unhealthy(errorMessage, e);
        }
    }
}
