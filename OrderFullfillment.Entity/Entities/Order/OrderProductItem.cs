using System.ComponentModel.DataAnnotations.Schema;
using OrderFullfillment.Entity.SeedWorks;

namespace OrderFullfillment.Entity.Entities.Order
{
    [Table("OrderProductItem")]
    public class OrderProductItem : EntityBase<int>
    {
        public Product Product { get; set; }
        public long Price { get; set; }
        public int Quantity { get; set; }

        public OrderProductItem()
        {
        }

        public OrderProductItem(Product product, long price, int quantity)
        {
            Product = product;
            Price = price;
            Quantity = quantity;
        }
    }
}