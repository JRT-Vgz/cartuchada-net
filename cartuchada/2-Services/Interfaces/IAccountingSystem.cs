
namespace _2_Services.Interfaces
{
    public interface IAccountingSystem
    {
        Task SumPurchasePriceToExpenses(DateTime dateTime, decimal purchasePrice);
    }
}
