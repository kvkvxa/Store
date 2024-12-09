using System;

namespace Store
{
    public class Order
    {
        public Order(string paylink)
        {
            if (Uri.IsWellFormedUriString(paylink, UriKind.Absolute) == false)
            {
                throw new ArgumentException("Invalid payment link.", nameof(paylink));
            }

            Paylink = paylink;
        }

        public string Paylink { get; private set; }
    }
}