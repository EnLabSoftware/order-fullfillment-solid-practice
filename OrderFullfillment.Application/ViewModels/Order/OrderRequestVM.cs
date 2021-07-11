using OrderFullfillment.Entity;

namespace OrderFullfillment.Application.ViewModels.Order
{
    public class OrderRequestVM
    {
        public OrderType Type { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public int BasketId { get; set; }
    }
}