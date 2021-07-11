using System.ComponentModel.DataAnnotations.Schema;

namespace OrderFullfillment.Entity.Entities.Invoice
{
    [Table("CompanyInvoice")]
    public class CompanyInvoice : InvoiceBase
    {
        public int CompanyId { get; set; }
        public int TaxNumber { get; set; }
        
        public override string GenerateInvoice()
        {
            return $"Generated invoice with {nameof(CompanyId)}: {CompanyId}, {nameof(TaxNumber)}: {TaxNumber}";
        }
    }
}