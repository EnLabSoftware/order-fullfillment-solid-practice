using System.ComponentModel.DataAnnotations.Schema;
using OrderFullfillment.Entity.Entities.Orders;

namespace OrderFullfillment.Entity.Entities.Invoice
{
    [Table("PersonalInvoice")]
    public class PersonalInvoice : InvoiceBase
    {
        public PersonalInvoice()
        {
        }

        public PersonalInvoice(Order order) : base(order)
        {
        }
        
        public override void Sign()
        {
            //... sign personal invoice
        }

        public override string Export()
        {
            //... exporting personal invoice
            return $"Exported personal invoice with {nameof(TotalCost)}: {TotalCost}";
        }
    }
}