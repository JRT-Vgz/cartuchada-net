
namespace _1_Domain.Interfaces
{
    public interface ISoldProduct
    {
        int IdProductType { get; }
        DateTime PurchaseDate { get; }
        decimal PurchasePrice { get; }
        DateTime SaleDate { get; }
        decimal SalePrice { get; }
        decimal Benefit { get; }
        string? Name { get; }

        void AssignSalePrice(decimal salePrice);

        void CalculateBenefit();

    }
}
