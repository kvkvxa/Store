namespace Store
{
    public interface IShopOperator
    {
        void EnsureGoodAvailability(Good good, int quantity);

        void CommitOrder(Cart cart);
    }
}
