namespace _3_Mappers.DTOs
{
    public class CartdrigePurchaseDto
    {
        public int IdProductType { get; set; }
        public int IdGame { get; set; }
        public int IdRegion { get; set; }
        public int IdCondition { get; set; }
        public decimal PurchasePrice { get; set; }
        public string Name { get; set; }
        public bool JAP { get; set; }
        public bool NA { get; set; }
        public bool PAL { get; set; }
        public string ProductType { get; set; }
        public string Region { get; set; }
        public string Condition { get; set; }
    }
}
