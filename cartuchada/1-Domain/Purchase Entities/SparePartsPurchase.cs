
namespace _1_Domain.Purchase_Entities
{
    public class SparePartsPurchase
    {
        public int IdSparePartType { get; private set; }
        public DateTime PurchaseDate { get; private set; }
        public string Concept { get; private set; }
        public decimal PurchasePrice { get; private set; }
        public string? Name { get; private set; }

        public SparePartsPurchase() 
        {
            PurchaseDate = DateTime.Now.Date;
        }
    }
}
