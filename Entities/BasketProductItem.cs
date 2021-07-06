using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using OrderFullfillment.SeedWorks;

namespace OrderFullfillment.Entities
{
    [Table("BasketProductItem")]
    public class BasketProductItem : EntityBase<int>
    {
        public Product Product { get; set; }
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