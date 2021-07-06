using System.ComponentModel.DataAnnotations.Schema;
using OrderFullfillment.SeedWorks;

namespace OrderFullfillment.Entities
{
    [Table("Product")]
    public class Product : EntityBase<int>
    {
        public int Name { get; set; }
        public int Quantity { get; set; }
    }
}