
namespace _2_Services.Exceptions
{
    public class StatisticSystemException : Exception
    {
        public StatisticSystemException(string message) : base($"ERROR: StatisticSystemException - {message}") { }
    }
}
