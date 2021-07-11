using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using OrderFullfillment.Entity.SeedWorks;

namespace OrderFullfillment.Entity.Entities.Order
{
    [Table("Order")]
    public class Order : EntityBase<int>
    {
        public string CustomerId { get; }
        public string Address { get; }
        public OrderStatus Status { get; set; }
        public ICollection<OrderProductItem> Products { get; set; }

        public long Total() => Products.Sum(_ => _.Price * _.Quantity);

        public Order(string customerId, string address)
        {
            CustomerId = customerId;
            Address = address;
            Status = OrderStatus.Created;
            Products = new List<OrderProductItem>();
        }
    }
}