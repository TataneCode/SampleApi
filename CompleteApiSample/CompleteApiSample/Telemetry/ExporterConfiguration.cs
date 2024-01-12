using CompleteApiSample.Common.Constants;
using CompleteApiSample.Telemetry.Logs;
using OpenTelemetry.Exporter;
using OpenTelemetry.Logs;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace CompleteApiSample.Telemetry
{
    /// <summary>
    /// Extensions methods to export TL data
    /// </summary>
    public static class ExporterConfiguration
    {
        /// <summary>
        /// Configure all telemetry options
        /// </summary>
        /// <param name="resource"></param>
        /// <param name="builder"></param>
        /// <param name="configuration"></param>
        public static void ConfigureTelemetry(this ResourceBuilder resource, WebApplicationBuilder builder)
        {
            builder.Logging.AddOpenTelemetry(logging =>
            {
                logging.IncludeFormattedMessage = true;
                logging
                .AddConsoleExporter()
                .AddProcessor(new LibraryProcessor())
                .AddOtlpExporter(opt =>
                {
                    opt.Protocol = OtlpExportProtocol.Grpc;
                });
            });

            builder.Services.AddOpenTelemetry()
                .WithMetrics(metricsProviderBuilder =>
                    metricsProviderBuilder
                    .SetResourceBuilder(resource)
                        .AddMeter(TelemetryKey.MeterName)
                        .AddOtlpExporter(opt =>
                        {
                            opt.Protocol = OtlpExportProtocol.Grpc;
                        }))
                .WithTracing(tracerProviderBuilder =>
                    tracerProviderBuilder
                        .AddSource(TelemetryTracer.TracerSource.Name)
                        .ConfigureResource(resource => resource.AddService(TelemetryKey.ServiceName))
                        .AddAspNetCoreInstrumentation()
                        .AddConsoleExporter()
                        .AddOtlpExporter(opt =>
                        {
                            opt.Protocol = OtlpExportProtocol.Grpc;
                        }));
        }
    }
}
