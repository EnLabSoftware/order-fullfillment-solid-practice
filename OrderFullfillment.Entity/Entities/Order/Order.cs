using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using OrderFullfillment.Entity.SeedWorks;

namespace OrderFullfillment.Entity.Entities.Orders
{
    [Table("Order")]
    public class Order : EntityBase
    {
        public OrderType Type { get; set; }
        public OrderStatus Status { get; set; }
        public string CustomerId { get; }
        public string Address { get; }
        public int? InvoiceId { get; set; }
        public virtual ICollection<OrderProductItem> Products { get; }

        public decimal Total() => Products.Sum(_ => _.Price * _.Quantity);

        public Order()
        {
        }

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