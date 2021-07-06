using System.ComponentModel.DataAnnotations.Schema;
using OrderFullfillment.SeedWorks;

namespace OrderFullfillment.Entities
{
    [Table("Product")]
    public class Product : EntityBase<int>
    {
        public int Name { get; set; }
        public long Price { get; set; }
        public int StockQuantity { get; set; }
    }
}