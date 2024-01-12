using CompleteApiSample.Common.Constants;
using CompleteApiSample.Infrastructure.Loggers;
using OpenTelemetry;
using OpenTelemetry.Logs;

namespace CompleteApiSample.Telemetry.Logs
{
    public class LibraryProcessor : BaseProcessor<LogRecord>
    {
        private const string Technical = "Technical";
        private const string Functional = "Functional";

        public override void OnEnd(LogRecord data)
        {
            if (data != null && data.Attributes != null)
            {
                var records = data.Attributes.ToDictionary(x => x.Key, x => x.Value);
                records[TelemetryKey.LoggerCategory] = data.CategoryName;
                var customCategory = Technical;
                if (data.CategoryName != null && data.CategoryName.Contains(nameof(FunctionalLogger)))
                    customCategory = Functional;
                records[TelemetryKey.CustomCategory] = customCategory;

                data.Attributes = records.ToList();
            }
            base.OnEnd(data);
        }
    }
}
