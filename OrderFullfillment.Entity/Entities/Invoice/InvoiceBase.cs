using OrderFullfillment.Entity.SeedWorks;

namespace OrderFullfillment.Entity.Entities.Invoice
{
    public abstract class InvoiceBase : EntityBase<int>
    {
        public Order.Order Order { get; set; }
        public abstract string GenerateInvoice();
    }
}