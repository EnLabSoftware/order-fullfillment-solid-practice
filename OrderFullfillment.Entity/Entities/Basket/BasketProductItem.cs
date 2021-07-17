using System.ComponentModel.DataAnnotations.Schema;
using OrderFullfillment.Entity.SeedWorks;

namespace OrderFullfillment.Entity.Entities.Basket
{
    [Table("BasketProductItem")]
    public class BasketProductItem : EntityBase
    {
        public virtual Product Product { get; set; }
        public int Quantity { get; set; }

        public BasketProductItem()
        {
        }

        public BasketProductItem(Product product)
        {
            Product = product;
            Quantity = 1;
        }
    }
}