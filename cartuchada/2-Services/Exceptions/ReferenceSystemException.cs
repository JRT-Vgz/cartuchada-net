
namespace _2_Services.Exceptions
{
    public class ReferenceSystemException : Exception
    {
        public ReferenceSystemException(string message) : base($"ERROR: ReferenceSystemException - {message}") { }
    }
}
