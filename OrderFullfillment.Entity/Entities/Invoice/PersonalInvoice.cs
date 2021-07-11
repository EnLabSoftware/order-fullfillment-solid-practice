using System.ComponentModel.DataAnnotations.Schema;

namespace OrderFullfillment.Entity.Entities.Invoice
{
    [Table("PersonalInvoice")]
    public class PersonalInvoice : InvoiceBase
    {
        public int CustomerId { get; set; }

        public PersonalInvoice(Order.Order order, int customerId) : base(order)
        {
            CustomerId = customerId;
        }

        public override string GenerateInvoice()
        {
            //... do something
            return $"Generated personal invoice with {nameof(CustomerId)}: {CustomerId}";
        }
    }
}