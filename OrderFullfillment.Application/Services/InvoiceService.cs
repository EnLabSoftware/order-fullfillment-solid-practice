using System;
using System.Threading.Tasks;
using OrderFullfillment.Application.SeedWorks;
using OrderFullfillment.Application.Services.Interfaces;
using OrderFullfillment.Entity;
using OrderFullfillment.Entity.Entities.Invoice;
using OrderFullfillment.Entity.Entities.Order;
using OrderFullfillment.Infrastructure.SeedWorks;

namespace OrderFullfillment.Application.Services
{
    public class InvoiceService : BaseService, IInvoiceService
    {

        private readonly IRepository<Order> _order;
        private readonly IRepository<CompanyInvoice> _companyInvoice;
        private readonly IRepository<PersonalInvoice> _personalInvoice;

        public InvoiceService(IUnitOfWork unitOfWork, 
            IRepository<CompanyInvoice> companyInvoice,
            IRepository<PersonalInvoice> personalInvoice,
            IRepository<Order> order) : base(unitOfWork)
        {
            _companyInvoice = companyInvoice;
            _personalInvoice = personalInvoice;
            _order = _order;
        }

        public async Task<int> CreateInvoice(Order order)
        {
            switch (order.Type)
            {
                case OrderType.Company:
                    var companyInvoice = new CompanyInvoice(order, 111);
                    _companyInvoice.Add(companyInvoice);
                    await UnitOfWork.CommitAsync();
                    return companyInvoice.Id;
                case OrderType.Personal:
                    var personalInvoice = new PersonalInvoice(order);
                    _personalInvoice.Add(personalInvoice);
                    await UnitOfWork.CommitAsync();
                    return personalInvoice.Id;
                default:
                    throw new Exception("OrderType not exist");
            }
        }

        public async Task<string> Export(int orderId)
        {
            var order = await _order.GetAsync(orderId);
            var invoiceId = order.InvoiceId.GetValueOrDefault();
            InvoiceBase invoice = null;
            switch (order.Type)
            {
                case OrderType.Company:
                    invoice = await _companyInvoice.GetAsync(invoiceId);
                    break;
                case OrderType.Personal:
                    invoice = await _personalInvoice.GetAsync(invoiceId);
                    break;
            }
            return invoice?.ExportInvoice();
        }
    }
}