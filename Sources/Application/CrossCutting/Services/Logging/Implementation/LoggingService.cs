using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.ApplicationInsights;
using System;

namespace Mmu.DrMuellersExampleApp.CrossCutting.Services.Logging.Implementation;

public class LoggingService : ILoggingService
{
    private readonly TelemetryClient _telemetryClient;

    public LoggingService(TelemetryClient telemetryClient)
    {
        _telemetryClient = telemetryClient;
    }

    public void LogError(string message)
    {
        _telemetryClient.TrackException(
            new ExceptionTelemetry
            {
                Message = message
            });
    }

    public void LogException(Exception ex)
    {
        _telemetryClient.TrackException(ex);
    }


    public void LogInformation(string message)
    {
        _telemetryClient.TrackTrace(
            message,
            SeverityLevel.Information,
            new Dictionary<string, string>
            {
                { "TestName", "TestValue" }
            });
    }
}