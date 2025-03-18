
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _3_Data.Models.Management_Models
{
    public class AccountingModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "DATE")]
        public DateTime Date { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Income { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Expenses { get; set; }
    }
}
