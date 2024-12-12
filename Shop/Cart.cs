using System;

namespace Store
{
    public class Cart : CellsContainer
    {
        private readonly IShopOperator _shop;

        public Cart(Shop shop)
        {
            _shop = shop;
        }

        public override void Add(Good good, int quantity)
        {
            _shop.EnsureGoodAvailability(good, quantity);
            base.Add(good, quantity);
        }

        public Order Order()
        {
            if (Cells.Count == 0)
            {
                throw new InvalidOperationException("Cart is empty");
            }

            _shop.CommitOrder(this);

            return new Order("https://payment.example/checkout");
        }
    }
}
