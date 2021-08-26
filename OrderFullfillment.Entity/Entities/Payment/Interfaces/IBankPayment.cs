namespace OrderFullfillment.Entity.Entities.Payment.Interfaces
{
    public interface IBankPayment: IPayment
    {
        public void AddBankInfo(string cardNumber, string ccv);
        public void PayWithInstallmentLoan();
    }
}