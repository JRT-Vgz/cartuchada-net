
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _3_Data.Models
{
    public class ConsoleModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IdReference { get; set; }
        public int IdProductType { get; set; }

        [Column(TypeName = "DATE")]
        public DateTime PurchaseDate { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal PurchasePrice { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal SparePartsPrice { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; }

        [ForeignKey("IdReference")]
        public ReferenceModel Reference { get; set; }

        [ForeignKey("IdProductType")]
        public ProductTypeModel ProductType { get; set; }
    }
}
