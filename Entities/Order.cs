using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using OrderFullfillment.SeedWorks;

namespace OrderFullfillment.Entities
{
    [Table("Order")]
    public class Order : EntityBase<int>
    {
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public OrderStatus Status { get; set; }
        public virtual ICollection<OrderProductItem> Products { get; set; }

        public long Total() => Products.Sum(_ => _.Price * _.Quantity);

        public Order(string customerName, string address)
        {
            CustomerName = customerName;
            Address = address;
            Status = OrderStatus.Created;
            Products = new List<OrderProductItem>();
        }
    }
}