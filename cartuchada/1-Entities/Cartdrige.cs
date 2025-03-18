using _1_Entities.Interfaces;
using System.Xml.Linq;

namespace _1_Entities
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

        public Cartdrige() { }
        public Cartdrige(int idProductType, int idGame, int idRegion, int idCondition, decimal purchasePrice)
        {
            IdProductType = idProductType;
            IdGame = idGame;
            IdRegion = idRegion;
            IdCondition = idCondition;
            PurchaseDate = DateTime.Now.Date;
            PurchasePrice = purchasePrice;
        }

        //public Cartdrige(int? id, int idReference, int idProductType, int idGame, int idSystem, 
        //    int idRegion, int idCondition, DateTime purchaseDate, decimal purchasePrice, string? name)
        //{
        //    Id = id;
        //    IdReference = idReference;
        //    IdProductType = idProductType;
        //    IdGame = idGame;
        //    IdSystem = idSystem;
        //    IdRegion = idRegion;
        //    IdCondition = idCondition;
        //    PurchaseDate = purchaseDate;
        //    PurchasePrice = purchasePrice;
        //    Name = name;
        //}

        public void AssignReference(int idReference, string reference) 
        { 
            if (IdReference != 0) { return; }

            IdReference = idReference;
            Reference = reference;
        }
    }
}
