using _1_Domain.Interfaces;

namespace _1_Domain.Product_Entities
{
    public class Cartdrige : IProduct
    {
        public int? Id { get; private set; }
        public int IdReference { get; private set; }
        public int IdProductType { get; private set; }
        public int IdGame { get; private set; }
        public int IdRegion { get; private set; }
        public int IdCondition { get; private set; }
        public DateTime PurchaseDate { get; private set; }
        public decimal PurchasePrice { get; private set; }
        public string? Name { get; private set; }
        public string? Reference { get; private set; }

        public Cartdrige()
        {
            PurchaseDate = DateTime.Now.Date;
        }

        public void AssignReference(int idReference, string reference)
        {
            if (IdReference != 0) { return; }

            IdReference = idReference;
            Reference = reference;
        }
    }
}
