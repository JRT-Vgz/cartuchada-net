
namespace _1_Domain.Sold_Product_Entities
{
    public class SoldSleeve
    {
        public int Id { get; private set; }
        public int IdSparePartType { get; private set; }
        public int Quantity { get; private set; }
        public DateTime SaleDate { get; private set; }
        public decimal SalePrice { get; private set; }
        public string Name { get; private set; }

        public SoldSleeve() 
        {
            SaleDate = DateTime.Now.Date;
        }
    }
}
