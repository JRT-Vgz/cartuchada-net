
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _3_Data.Models
{
    public class CartdrigeModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IdReference { get; set; }
        public int IdProductType { get; set; }
        public int IdGame { get; set; }
        public int IdRegion { get; set; }
        public int IdCondition { get; set; }

        [Column(TypeName = "DATE")]
        public DateTime PurchaseDate { get; set; }
        public decimal PurchasePrice { get; set; }

        [ForeignKey("IdReference")]
        public ReferenceModel Reference { get; set; }

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
