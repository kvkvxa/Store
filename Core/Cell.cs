using System;

namespace Store
{
    public class Cell : IReadonlyCell, IModifableCell
    {
        public Cell(Good good, int quantity)
        {
            Good = good ?? throw new NullReferenceException($"{nameof(good)} is null");

            if (quantity <= 0)
            {
                throw new ArgumentOutOfRangeException($"{nameof(quantity)} must be greater than 0.");
            }

            Quantity = quantity;
        }

        public Good Good { get; private set; }

        public int Quantity { get; private set; }

        public void Merge(int quantity)
        {
            if (quantity <= 0)
            {
                throw new ArgumentException("Quantity must be greater than 0", nameof(quantity));
            }

            if (Quantity + quantity < 0)
            {
                throw new OverflowException("Quantity of goods is too big");
            }

            Quantity += quantity;
        }

        public void DecreaseQuantity(int amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Amount must be greater than 0", nameof(amount));
            }

            if (amount > Quantity)
            {
                throw new InvalidOperationException($"Cannot decrease quantity by {amount}. Available: {Quantity}");
            }

            Quantity -= amount;
        }
    }
}