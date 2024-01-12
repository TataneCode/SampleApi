namespace CompleteApiSample.Errors
{
    public class ErrorMessage
    {
        public required int StatusCode { get; set; }

        public required string Message { get; set; }

        public string? Stacktrace { get; set; }
    }
}
