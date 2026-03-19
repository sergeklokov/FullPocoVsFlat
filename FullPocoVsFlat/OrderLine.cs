using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullPocoVsFlat
{
    public class OrderLine
    {
        public int Id { get; private set; }
        public Product Product { get; private set; }
        public int Quantity { get; private set; }
        public Money UnitPrice { get; private set; }
        public Money Subtotal => new(UnitPrice.Amount * Quantity, UnitPrice.Currency);

        private OrderLine() { Product = new Product(0, string.Empty); UnitPrice = new Money(0, "USD"); }
        public OrderLine(int id, Product product, int quantity, Money unitPrice)
        {
            if (quantity <= 0) throw new ArgumentOutOfRangeException(nameof(quantity));
            Id = id;
            Product = product ?? throw new ArgumentNullException(nameof(product));
            Quantity = quantity;
            UnitPrice = unitPrice;
        }
    }
}
