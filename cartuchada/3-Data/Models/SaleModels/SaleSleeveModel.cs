
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using _3_Data.Models.Spare_Parts_Models;

namespace _3_Data.Models.SaleModels
{
    public class SaleSleeveModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IdSparePartType { get; set; }

        public int Quantity { get; set; }

        [Column(TypeName = "DATE")]
        public DateTime SaleDate { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal SalePrice { get; set; }


        [ForeignKey("IdSparePartType")]
        public SparePartTypeModel SparePartType { get; set; }
    }
}
