using System;

namespace Store
{
    public class Shop : IShopOperator
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

        public void EnsureGoodAvailability(Good good, int quantity)
        {
            var cell = _warehouse.GetCellByName(good.Name) ?? throw new InvalidOperationException($"There is no {good.Name} in the store.");

            if (cell.Quantity < quantity)
            {
                throw new InvalidOperationException($"There is not enough {good.Name} in the store.");
            }
        }

        public void CommitOrder(Cart cart)
        {
            ValidateOrder(cart);

            foreach (IReadonlyCell cell in cart.Cells)
            {
                _warehouse.GetCellByName(cell.Good.Name)?.DecreaseQuantity(cell.Quantity);
            }
        }

        private void ValidateOrder(Cart cart)
        {
            foreach (IReadonlyCell cartCell in cart.Cells)
            {
                var warehouseCell = _warehouse.GetCellByName(cartCell.Good.Name);

                if (warehouseCell == null || warehouseCell.Quantity < cartCell.Quantity)
                {
                    throw new InvalidOperationException($"Not enough of {cartCell.Good.Name} in stock.");
                }
            }
        }
    }
}