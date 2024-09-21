using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductManagement.Models.Entities
{
    public class Nomenklature
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        [Column(TypeName = "decimal(6, 2)")]
        public required decimal Price { get; set; }
        public ICollection<Link> ChildLinks { get; set; }
        public ICollection<Link> ParentLinks { get; set; }


    }
}
