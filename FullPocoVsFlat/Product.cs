using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullPocoVsFlat
{
    public class Product
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        private Product() { Name = string.Empty; } // for ORMs if needed
        public Product(int id, string name)
        {
            Id = id;
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }
    }
}
