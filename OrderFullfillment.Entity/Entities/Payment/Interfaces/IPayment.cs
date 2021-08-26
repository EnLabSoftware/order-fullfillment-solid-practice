namespace OrderFullfillment.Entity.Entities.Payment.Interfaces
{
    public interface IPayment
    {
        public void Pay(int amount);
        public void ScanQRCode();
    }
}