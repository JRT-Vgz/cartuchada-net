
using _1_Domain.Interfaces;

namespace _1_Domain.Product_Entities
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

        public VideoConsole()
        {
            PurchaseDate = DateTime.Now.Date;
        }

        public void CalculateTotalPrice()
        {
            TotalPrice = PurchasePrice + SparePartsPrice;
        }

        public void SumToSparePartsPrice(decimal sparePartsPrice)
        {
            SparePartsPrice += sparePartsPrice;
            CalculateTotalPrice();
        }

        public void WithdrawFromSparePartsPrice(decimal sparePartsPriceToWithdraw)
        {
            SparePartsPrice -= sparePartsPriceToWithdraw;

            if (SparePartsPrice < 0) { SparePartsPrice = 0; }
            CalculateTotalPrice();
        }

        public void AssignReference(int idReference, string reference)
        {
            if (IdReference != 0) { return; }

            IdReference = idReference;
            Reference = reference;
        }
    }
}
