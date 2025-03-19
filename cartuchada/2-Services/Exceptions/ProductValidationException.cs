
namespace _2_Services.Exceptions
{
    public class ProductValidationException : Exception
    {
        public List<string> Errors { get; set; }
        public ProductValidationException(List<string> errorsList) : base("ERROR: ProductValidationException:")
        { Errors = errorsList; }

        public ProductValidationException(string message) : base($"ERROR: ProductValidationException: {message}") { }
    }
}
