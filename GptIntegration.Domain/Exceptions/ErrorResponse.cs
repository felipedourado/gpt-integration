namespace GptIntegration.Domain.Exceptions
{
    public class ErrorResponse
    {
        public string Message { get; set; }
        public string Exception { get; set; }
        public string StackTrace { get; set; }
        public DateTime Data { get; set; }
    }
}
