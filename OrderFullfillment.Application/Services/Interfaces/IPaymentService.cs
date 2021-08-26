using System.Threading.Tasks;
using OrderFullfillment.Entity.Entities;
using OrderFullfillment.Entity.Entities.Payment;

namespace OrderFullfillment.Application.Services.Interfaces
{
    public interface IPaymentService
    {
        public Task PayWithBankAccount(BankPayment payment, int amount);
        public Task PayWithEWalletAccount(EWalletPayment payment, int amount);
    }
}