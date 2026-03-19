
using System;

namespace Poco48Demo
{
    public sealed class OrderLine
    {
        public int Id { get; private set; }
        public Product Product { get; private set; }
        public int Quantity { get; private set; }
        public Money UnitPrice { get; private set; }

        public Money Subtotal
        {
            get { return new Money(UnitPrice.Amount * Quantity, UnitPrice.Currency); }
        }

        public OrderLine(int id, Product product, int quantity, Money unitPrice)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));
            if (unitPrice == null) throw new ArgumentNullException(nameof(unitPrice));
            if (quantity <= 0) throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity must be > 0");

            Id = id;
            Product = product;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }
    }
}
