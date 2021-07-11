using System.ComponentModel.DataAnnotations.Schema;
using OrderFullfillment.Entity.SeedWorks;

namespace OrderFullfillment.Entity.Entities.Order
{
    [Table("OrderProductItem")]
    public class OrderProductItem : EntityBase<int>
    {
        public Product Product { get; }
        public long Price { get; }
        public int Quantity { get; }

        public OrderProductItem()
        {
        }

        public OrderProductItem(Product product, int quantity)
        {
            Product = product;
            Price = product.Price;
            Quantity = quantity;
        }
    }
}