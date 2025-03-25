
namespace _2_Services.Exceptions
{
    public class DataValidationException : Exception
    {
        public List<string> Errors { get; set; }
        public DataValidationException(List<string> errorsList) : base("ERROR: DataValidationException:")
        { Errors = errorsList; }

        public DataValidationException(string message) : base($"ERROR: DataValidationException: {message}") { }
    }
}
