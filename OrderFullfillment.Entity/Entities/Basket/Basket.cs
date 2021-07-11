using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using OrderFullfillment.Entity.SeedWorks;

namespace OrderFullfillment.Entity.Entities.Basket
{
    [Table("Basket")]
    public class Basket : EntityBase<int>
    {
        public int UserId { get; set; }
        public bool IsResolved { get; set; }
        public virtual ICollection<BasketProductItem> Products { get; set; }

        public Basket(int userId)
        {
            UserId = userId;
        }
    }
}