
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _3_Data.Models.SaleModels
{
    public class SoldCartdrigeModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IdProductType { get; set; }
        public int IdGame { get; set; }
        public int IdRegion { get; set; }
        public int IdCondition { get; set; }

        [Column(TypeName = "DATE")]
        public DateTime PurchaseDate { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal PurchasePrice { get; set; }

        [Column(TypeName = "DATE")]
        public DateTime SaleDate { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal SalePrice { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Benefit { get; set; }



        [ForeignKey("IdProductType")]
        public ProductTypeModel ProductType { get; set; }

        [ForeignKey("IdGame")]
        public GameCatalogueModel Game { get; set; }

        [ForeignKey("IdRegion")]
        public RegionModel Region { get; set; }

        [ForeignKey("IdCondition")]
        public ConditionModel Condition { get; set; }
    }
}
