using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderFullfillment.Entities.Invoice
{
    [Table("CompanyInvoice")]
    public class CompanyInvoice : InvoiceBase
    {
        public int CompanyId { get; set; }
        public int TaxNumber { get; set; }
        
        public override void Generate()
        {
            Console.WriteLine("Company invoice generated");
        }

        public override void Print()
        {
            Console.WriteLine("Company invoice printed");
        }
    }
}