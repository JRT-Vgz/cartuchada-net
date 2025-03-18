
using _1_Entities.Interfaces;
using System.Xml.Linq;

namespace _1_Entities
{
    public class VideoConsole : IProduct
    {
        public int Id { get; private set; }
        public int IdReference { get; private set; }
        public int IdProductType { get; private set; }
        public DateTime PurchaseDate { get; private set; }
        public decimal PurchasePrice { get; private set; }
        public decimal SparePartsPrice { get; private set; }
        public decimal TotalPrice { get; private set; }
        public string? Name { get; private set; }
        public string? Reference { get; private set; }

        public VideoConsole() { }
        public VideoConsole(int idProductType, decimal purchasePrice, decimal sparePartsPrice = 0)
        {
            IdProductType = idProductType;
            PurchaseDate = DateTime.Now.Date;
            PurchasePrice = purchasePrice;
            SparePartsPrice = sparePartsPrice;
            TotalPrice = CalculateTotalPrice();
        }

        private decimal CalculateTotalPrice()
            => PurchasePrice + SparePartsPrice;

        public void AssignReference(int idReference, string reference)
        {
            if (IdReference != 0) { return; }

            IdReference = idReference;
            Reference = reference;
        }
    }
}
