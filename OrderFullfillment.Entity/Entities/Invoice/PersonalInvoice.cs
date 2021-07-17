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

        public override string ExportInvoice()
        {
            //... do something
            return $"Exported personal invoice";
        }
    }
}