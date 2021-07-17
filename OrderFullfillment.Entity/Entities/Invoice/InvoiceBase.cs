using OrderFullfillment.Entity.Entities.Orders;
using OrderFullfillment.Entity.SeedWorks;

namespace OrderFullfillment.Entity.Entities.Invoice
{
    public abstract class InvoiceBase : EntityBase
    {
        public Order Order { get; set; }
        public abstract string ExportInvoice();

        protected InvoiceBase()
        {
        }

        protected InvoiceBase(Order order)
        {
            Order = order;
        }
    }
}