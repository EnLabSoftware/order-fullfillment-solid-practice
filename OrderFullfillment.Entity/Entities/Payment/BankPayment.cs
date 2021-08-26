using OrderFullfillment.Entity.Entities.Payment.Interfaces;

namespace OrderFullfillment.Entity.Entities.Payment
{
    public class BankPayment: IBankPayment
    {
        public void Pay(int amount)
        {
            //... detail
        }

        public void ScanQRCode()
        {
            //... detail
        }

        public void AddBankInfo(string cardNumber, string ccv)
        {
            //... detail
        }

        public void PayWithInstallmentLoan()
        {
            //... detail
        }
    }
}