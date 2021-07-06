using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using OrderFullfillment.SeedWorks;

namespace OrderFullfillment.Entities
{
    [Table("Order")]
    public class Order : EntityBase<int>
    {
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public OrderStatus Status { get; set; }
   
        public virtual ICollection<Product> Products { get; set; }
    }
}