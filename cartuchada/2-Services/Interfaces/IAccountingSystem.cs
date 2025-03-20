
namespace _2_Services.Interfaces
{
    public interface IAccountingSystem
    {
        Task SumPurchasePriceToExpensesAsync(DateTime dateTime, decimal purchasePrice);
        Task SumSalePriceToIncomeAsync(DateTime dateTime, decimal salePrice);
    }
}
