namespace Store
{
    public class Warehouse : CellsContainer
    {
        public void Deliver(Good good, int quantity)
        {
            Add(good, quantity);
        }
    }
}