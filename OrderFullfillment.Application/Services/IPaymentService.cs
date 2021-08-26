using System.Threading.Tasks;
using OrderFullfillment.Application.SeedWorks;
using OrderFullfillment.Application.Services.Interfaces;
using OrderFullfillment.Entity.Entities.Payment;
using OrderFullfillment.Infrastructure.SeedWorks;

namespace OrderFullfillment.Application.Services
{
    public class PaymentService : BaseService, IPaymentService
    {
        private readonly IRepository<BankPayment> _bankPaymentRepository;
        private readonly IRepository<EWalletPayment> _eWalletPaymentRepository;
        
        public PaymentService(IUnitOfWork unitOfWork, IRepository<BankPayment> bankPaymentRepository, IRepository<EWalletPayment> eWalletPaymentRepository) : base(unitOfWork)
        {
            _bankPaymentRepository = bankPaymentRepository;
            _eWalletPaymentRepository = eWalletPaymentRepository;
        }

        public async Task PayWithBankAccount(BankPayment payment, int amount)
        {
            // Handle logic
        }

        public async Task PayWithEWalletAccount(EWalletPayment payment, int amount)
        {
            // Handle logic
        }
    }
}