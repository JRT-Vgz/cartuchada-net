
using _1_Domain.Interfaces;

namespace _1_Domain.Sold_Product_Entities
{
    public class SoldCartdrige : ISoldProduct
    {
        public int? Id { get; private set; }
        public int IdProductType { get; private set; }
        public int IdGame { get; private set; }
        public int IdRegion { get; private set; }
        public int IdCondition { get; private set; }
        public DateTime PurchaseDate { get; private set; }
        public decimal PurchasePrice { get; private set; }
        public DateTime SaleDate { get; private set; }
        public decimal SalePrice { get; private set; }
        public decimal Benefit { get; private set; }
        public string? Name { get; private set; }
        public string Region { get; private set; }
        public string Condition { get; private set; }
        public int IdCartdrige { get; private set; }

        public SoldCartdrige()
        {
            SaleDate = DateTime.Now.Date;
        }

        public void AssignSalePrice(decimal salePrice)
        {
            if (SalePrice != 0) { return; }

            SalePrice = salePrice;
            CalculateBenefit();
        }

        public void CalculateBenefit()
        {
            Benefit = SalePrice - PurchasePrice;
        }
    }
}
