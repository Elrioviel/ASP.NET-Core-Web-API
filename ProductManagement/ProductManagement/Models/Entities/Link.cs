using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductManagement.Models.Entities
{
    public class Link
    {
        [Key]
        public int Id { get; set; }
        // Ссылка на текущую продукцию.
        public required int NomenklatureId { get; set; }
        public Nomenklature Nomenklature { get; set; }
        // Ссылка на вышестоящую продукцию.
        public required int ParentId { get; set; }
        public Nomenklature Parent { get; set; }
        // Количество текущих изделий, входящих в вышестоящее.
        public required int Quantity {  get; set; }
    }
}
