namespace OrderFullfillment.Entity
{
    public enum OrderType
    {
        Company = 1,
        Personal = 2,
    }
    public enum OrderStatus
    {
        Created = 1,
        Paid = 2,
        Shipped = 3,
    }
}