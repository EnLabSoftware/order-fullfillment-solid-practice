using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using OrderFullfillment.SeedWorks;

namespace OrderFullfillment.Entities
{
    [Table("Basket")]
    public class Basket : EntityBase<int>
    {
        public virtual ICollection<Product> Products { get; set; }
    }
}