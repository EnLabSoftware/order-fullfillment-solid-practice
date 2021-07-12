using System.ComponentModel.DataAnnotations.Schema;

namespace OrderFullfillment.Entity.Entities.Invoice
{
    [Table("PersonalInvoice")]
    public class PersonalInvoice : InvoiceBase
    {
        public PersonalInvoice(Order.Order order) : base(order)
        {
        }

        public override string ExportInvoice()
        {
            //... do something
            return $"Exported personal invoice";
        }
    }
}