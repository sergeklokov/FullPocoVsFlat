using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullPocoVsFlat
{
    public class Customer
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        private Customer() { Name = string.Empty; }
        public Customer(int id, string name)
        {
            Id = id;
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }
    }
}
