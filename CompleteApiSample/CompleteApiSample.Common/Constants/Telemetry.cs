using System.Diagnostics;
using System.Diagnostics.Metrics;

namespace CompleteApiSample.Common.Constants
{
    public static class TelemetryKey
    {
        // Service
        public const string ServiceName = "library_service";

        // Meter
        public const string MeterName = "library_meter";
        public const string Username = "username";

        // Trace
        public const string TraceName = "library_trace";

        // Log
        public const string LoggerCategory = "generic_category";
        public const string CustomCategory = "library_logger_category";
    }

    public static class TelemetryMeter
    {
        private static readonly Meter Meter = new(TelemetryKey.MeterName);
        public static readonly Counter<long> BookAddingCounter = Meter.CreateCounter<long>($"{TelemetryKey.MeterName}_add_book_counter");
        public static readonly Counter<long> AuthorAddingCounter = Meter.CreateCounter<long>($"{TelemetryKey.MeterName}_add_author_counter");
    }

    public static class TelemetryTracer
    {
        public static readonly ActivitySource TracerSource = new(TelemetryKey.ServiceName);
    }
}
