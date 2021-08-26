namespace OrderFullfillment.Entity.Entities.Payment.Interfaces
{
    public interface IEWalletPayment: IPayment
    {
        public void LinkToBank(string bankAddress);
        public void TopUp(int amount);
    }
}