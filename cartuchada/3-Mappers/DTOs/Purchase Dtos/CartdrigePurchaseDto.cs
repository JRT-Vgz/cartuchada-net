
using _3_Mappers.DTOs.Purchase_Dtos;

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
    }
}
