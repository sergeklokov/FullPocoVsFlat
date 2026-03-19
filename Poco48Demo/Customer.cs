
using System;

namespace Poco48Demo
{
    public sealed class Customer
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public Customer(int id, string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Customer name is required.", nameof(name));

            Id = id;
            Name = name;
        }
    }
}
