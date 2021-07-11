using System.Threading.Tasks;
using OrderFullfillment.Application.SeedWorks;
using OrderFullfillment.Application.Services.Interfaces;
using OrderFullfillment.Application.ViewModels.Order;
using OrderFullfillment.Entity;
using OrderFullfillment.Entity.Entities.Basket;
using OrderFullfillment.Entity.Entities.Invoice;
using OrderFullfillment.Entity.Entities.Order;
using OrderFullfillment.Infrastructure.SeedWorks;

namespace OrderFullfillment.Application.Services
{
    public class OrderService : BaseService, IOrderService
    {
        private readonly IBasketService _basketService;

        private readonly IRepository<Order> _orderRepo;
        private readonly IRepository<Basket> _basketRepo;
        private readonly IRepository<CompanyInvoice> _companyInvoice;
        private readonly IRepository<PersonalInvoice> _personalInvoice;

        public OrderService(IUnitOfWork unitOfWork, 
            IBasketService basketService, 
            IRepository<Order> orderRepo,
            IRepository<Basket> basketRepo,
            IRepository<CompanyInvoice> companyInvoice,
            IRepository<PersonalInvoice> personalInvoice) : base(unitOfWork)
        {
            _orderRepo = orderRepo;
            _basketRepo = basketRepo;
            _basketService = basketService;
            _companyInvoice = companyInvoice;
            _personalInvoice = personalInvoice;
        }

        public async Task<Order> Get(int id)
        {
            return await _orderRepo.GetAsync(id);
        }

        public async Task<Order> CreateOrder(OrderRequestVM orderInfo)
        {
            var order = new Order(orderInfo.Type, orderInfo.CustomerName, orderInfo.Address);
            var basket = await _basketRepo.GetAsync(orderInfo.BasketId);
            foreach (var item in basket.Products)
            {
                order.AddProductItem(item.Product, item.Quantity);
            }

            await UnitOfWork.ExecuteTransactionAsync(async () =>
            {
                _orderRepo.Add(order);
                await _basketService.MarkedAsResolved(orderInfo.BasketId);
                return await UnitOfWork.CommitAsync();
            });
            return order;
        }

        public async Task MarkOrderAsPaid(int orderId)
        {
            var order = await _orderRepo.GetAsync(orderId);
            order.Status = OrderStatus.Paid;
            await UnitOfWork.CommitAsync();
        }

        public async void CreateInvoice(Order order)
        {
            switch (order.Type)
            {
                case OrderType.Company:
                    _companyInvoice.Add(new CompanyInvoice(order, 111));
                    break;
                case OrderType.Personal:
                    _personalInvoice.Add(new PersonalInvoice(order, 1));
                    break;
            }
            await UnitOfWork.CommitAsync();
        }
    }
}