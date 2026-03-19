
using System;

namespace Poco48Demo
{
    public sealed class Product
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public Product(int id, string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Product name is required.", nameof(name));

            Id = id;
            Name = name;
        }
    }
}
