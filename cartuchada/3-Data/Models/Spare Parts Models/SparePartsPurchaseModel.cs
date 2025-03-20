
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _3_Data.Models.Spare_Parts_Models
{
    public class SparePartsPurchaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IdSparePartType { get; set; }

        [Column(TypeName = "DATE")]
        public DateTime PurchaseDate { get; set; }

        [StringLength(255)]
        public string Concept { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal PurchasePrice { get; set; }

        [ForeignKey("IdSparePartType")]
        public SparePartTypeModel SparePartType { get; set; }
    }
}
