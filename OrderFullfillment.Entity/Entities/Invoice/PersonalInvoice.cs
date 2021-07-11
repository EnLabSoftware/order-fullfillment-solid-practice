using System.ComponentModel.DataAnnotations.Schema;

namespace OrderFullfillment.Entity.Entities.Invoice
{
    [Table("PersonalInvoice")]
    public class PersonalInvoice : InvoiceBase
    {
        public int CustomerId { get; set; }
        
        public override string GenerateInvoice()
        {
            return $"Generated invoice with {nameof(CustomerId)}: {CustomerId}";
        }
    }
}