using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using OrderFullfillment.Entity.SeedWorks;

namespace OrderFullfillment.Entity.Entities.Order
{
    [Table("Order")]
    public class Order : EntityBase<int>
    {
        public OrderType Type { get; set; }
        public OrderStatus Status { get; set; }
        public string CustomerId { get; }
        public string Address { get; }
        public ICollection<OrderProductItem> Products { get; }

        public long Total() => Products.Sum(_ => _.Price * _.Quantity);

        public Order(OrderType type, string customerId, string address)
        {
            Type = type;
            CustomerId = customerId;
            Address = address;
            Status = OrderStatus.Created;
            Products = new List<OrderProductItem>();
        }

        public void AddProductItem(Product product, int quantity)
        {
            Products.Add(new OrderProductItem(product, quantity));
        }
    }
}