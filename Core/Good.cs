using System;

namespace Store
{
    public class Good
    {
        public Good(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Name cannot be empty", nameof(name));
            }

            Name = name;
        }

        public string Name { get; private set; }
    }
}