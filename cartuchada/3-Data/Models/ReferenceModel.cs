
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _3_Data.Models
{
    public class ReferenceModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IdProductType { get; set; }
        public string Name { get; set; }
        public bool Assigned { get; set; }

        [ForeignKey("IdProductType")]
        public ProductTypeModel ProductType { get; set; }

    }
}
