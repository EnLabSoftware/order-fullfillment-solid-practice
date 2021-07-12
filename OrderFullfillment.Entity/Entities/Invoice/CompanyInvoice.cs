using System.ComponentModel.DataAnnotations.Schema;

namespace OrderFullfillment.Entity.Entities.Invoice
{
    [Table("CompanyInvoice")]
    public class CompanyInvoice : InvoiceBase
    {
        public int TaxNumber { get; set; }

        public CompanyInvoice(Order.Order order, int taxNumber) : base(order)
        {
            TaxNumber = taxNumber;
        }

        public override string ExportInvoice()
        {
            //... do something
            return $"Exported company invoice with {nameof(TaxNumber)}: {TaxNumber}";
        }
    }
}