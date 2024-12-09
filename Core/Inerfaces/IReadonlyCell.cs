namespace Store
{
    public interface IReadonlyCell
    {
        Good Good { get; }

        int Quantity { get; }
    }
}
