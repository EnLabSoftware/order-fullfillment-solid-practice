using OrderFullfillment.SeedWorks;

namespace OrderFullfillment.Entities.Invoice
{
    public abstract class InvoiceBase : EntityBase<int>
    {
        public string CustomerId { get; set; }
        public string Address { get; set; }
        public decimal Total { get; set; }
        public Order.Order Order { get; set; }

        public abstract void Generate();
        public abstract void Print();
    }
}