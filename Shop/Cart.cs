using System;

namespace Store
{
    public class Cart : CellsContainer
    {
        private readonly Shop _shop;

        public Cart(Shop shop)
        {
            _shop = shop;
        }

        public override void Add(Good good, int quantity)
        {
            if (_shop.HasGood(good, quantity) == false)
            {
                throw new InvalidOperationException($"There is no {good.Name} in shop.");
            }

            base.Add(good, quantity);
        }

        public Order Order()
        {
            if (GetCells().Count == 0)
            {
                throw new InvalidOperationException("Cart is empty");
            }

            _shop.CommitOrder(this);

            return new Order("https://payment.example/checkout");
        }
    }
}
