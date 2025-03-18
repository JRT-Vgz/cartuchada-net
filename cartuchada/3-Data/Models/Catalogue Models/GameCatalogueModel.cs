
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _3_Data.Models
{
    public class GameCatalogueModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IdProductType { get; set; }
        public string Name { get; set; }
        public bool JAP { get; set; }
        public bool NA { get; set; }
        public bool PAL { get; set; }

        [ForeignKey("IdProductType")]
        public ProductTypeModel ProductType { get; set; }
    }
}
