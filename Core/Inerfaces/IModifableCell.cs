namespace Store
{
    public interface IModifableCell
    {
        int Quantity { get; }

        void DecreaseQuantity(int amount);

        void Merge(int quantity);
    }
}
