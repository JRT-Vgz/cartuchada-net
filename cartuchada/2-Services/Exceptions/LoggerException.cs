
namespace _2_Services.Exceptions
{
    public class LoggerException : Exception
    {
        public LoggerException(string message) : base($"ERROR: LoggerException - {message}") { }
    }
}
