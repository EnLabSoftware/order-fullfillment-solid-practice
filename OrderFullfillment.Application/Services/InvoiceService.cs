using System;
using System.Threading.Tasks;
using OrderFullfillment.Application.SeedWorks;
using OrderFullfillment.Application.Services.Interfaces;
using OrderFullfillment.Entity;
using OrderFullfillment.Entity.Entities.Invoice;
using OrderFullfillment.Entity.Entities.Orders;
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
            _order = order;
        }

        public async Task<int> CreateInvoice(Order order)
        {
            switch (order.Type)
            {
                case OrderType.Company:
                    var companyInvoice = new CompanyInvoice(order, 111);
                    _companyInvoice.Add(companyInvoice);
                    await UnitOfWork.SaveChangeAsync();
                    return companyInvoice.Id;
                case OrderType.Personal:
                    var personalInvoice = new PersonalInvoice(order);
                    _personalInvoice.Add(personalInvoice);
                    await UnitOfWork.SaveChangeAsync();
                    return personalInvoice.Id;
                default:
                    throw new Exception("OrderType not exist");
            }
        }

        public async Task Sign(int orderId)
        {
            var order = await _order.GetAsync(orderId);
            var invoiceId = order.InvoiceId.GetValueOrDefault();
            var invoice = await GetInvoiceByType(order, invoiceId);
            invoice?.Sign();
        }

        public async Task<string> Export(int orderId)
        {
            var order = await _order.GetAsync(orderId);
            var invoiceId = order.InvoiceId.GetValueOrDefault();
            var invoice = await GetInvoiceByType(order, invoiceId);
            return invoice?.Export();
        }

        private async Task<InvoiceBase> GetInvoiceByType(Order order, int invoiceId)
        {
            switch (order.Type)
            {
                case OrderType.Company:
                    return await _companyInvoice.GetAsync(invoiceId);
                case OrderType.Personal:
                    return await _personalInvoice.GetAsync(invoiceId);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}