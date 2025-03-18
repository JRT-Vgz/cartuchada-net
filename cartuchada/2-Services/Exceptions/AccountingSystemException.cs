
namespace _2_Services.Exceptions
{
    public class AccountingSystemException : Exception
    {
        public AccountingSystemException(string message) : base($"ERROR: AccountingSystemException - {message}") { }
    }
}
