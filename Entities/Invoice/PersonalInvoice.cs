using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderFullfillment.Entities.Invoice
{
    [Table("PersonalInvoice")]
    public class PersonalInvoice : InvoiceBase
    {
        public int CustomerId { get; set; }
        
        public override void Generate()
        {
            Console.WriteLine("Personal invoice generated");
        }

        public override void Print()
        {
            Console.WriteLine("Personal invoice printed");
        }
    }
}