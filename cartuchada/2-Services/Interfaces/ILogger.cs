
namespace _2_Services.Interfaces
{
    public interface ILogger
    {
        Task WriteLogEntryAsync(string logEntry);
    }
}
