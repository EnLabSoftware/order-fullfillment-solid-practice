using System.ComponentModel.DataAnnotations.Schema;
using OrderFullfillment.Entity.Entities.Orders;

namespace OrderFullfillment.Entity.Entities.Invoice
{
    [Table("CompanyInvoice")]
    public class CompanyInvoice : InvoiceBase
    {
        public int TaxNumber { get; set; }

        public CompanyInvoice()
        {
        }

        public CompanyInvoice(Order order, int taxNumber) : base(order)
        {
            TaxNumber = taxNumber;
        }

        public override void Sign()
        {
            //... sign company invoice
        }
        
        public override string Export()
        {
            //... exporting company invoice
            return $"Exported company invoice with {nameof(TotalCost)}: {TotalCost}, {nameof(TaxNumber)}: {TaxNumber}";
        }
    }
}