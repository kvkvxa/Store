using System;

namespace Store
{
    public class Shop
    {
        private readonly Warehouse _warehouse;

        public Shop(Warehouse warehouse)
        {
            _warehouse = warehouse ?? throw new ArgumentNullException(nameof(warehouse));
        }

        public Cart Cart()
        {
            return new Cart(this);
        }

        public bool HasGood(Good good, int quantity)
        {
            if (_warehouse.GetCellByName(good.Name) == null)
            {
                throw new InvalidOperationException($"There in no {good.Name} in the store");
            }

            if (_warehouse.GetCellByName(good.Name).Quantity < quantity)
            {
                throw new InvalidOperationException($"There in not enough {good.Name} in the store");
            }

            return true;
        }

        public void CommitOrder(Cart cart)
        {
            foreach (IReadonlyCell cell in cart.GetCells())
            {
                _warehouse.GetCellByName(cell.Good.Name)?.DecreaseQuantity(cell.Quantity);
            }
        }
    }
}