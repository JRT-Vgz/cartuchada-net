
namespace _1_Entities.Sold_Product_Entities
{
    public class SoldVideoConsole
    {
        public int? Id { get; private set; }
        public int IdProductType { get; private set; }
        public DateTime PurchaseDate { get; private set; }
        public decimal PurchasePrice { get; private set; }
        public decimal SparePartsPrice { get; private set; }
        public decimal TotalPrice { get; private set; }
        public DateTime SaleDate { get; private set; }
        public decimal SalePrice { get; private set; }
        public decimal Benefit { get; private set; }
        public string? Name { get; private set; }
        public int IdConsole { get; private set; }

        public SoldVideoConsole()
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
            Benefit = SalePrice - TotalPrice;
        }
    }
}
