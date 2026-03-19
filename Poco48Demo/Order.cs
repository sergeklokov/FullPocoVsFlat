
using System;
using System.Collections.Generic;
using System.Linq;

namespace Poco48Demo
{
    public sealed class Order
    {
        private readonly List<OrderLine> _lines = new List<OrderLine>();

        public int Id { get; private set; }
        public DateTime OrderDateUtc { get; private set; }
        public Customer Customer { get; private set; }

        public IReadOnlyCollection<OrderLine> Lines { get { return _lines.AsReadOnly(); } }

        public Money Total
        {
            get
            {
                var currency = _lines.Count > 0 ? _lines[0].UnitPrice.Currency : "USD";
                var sum = _lines.Sum(l => l.Subtotal.Amount);
                return new Money(sum, currency);
            }
        }

        public Order(int id, Customer customer, DateTime orderDateUtc)
        {
            if (customer == null) throw new ArgumentNullException(nameof(customer));
            Id = id;
            Customer = customer;
            OrderDateUtc = orderDateUtc;
        }

        public void AddLine(Product product, int quantity, Money unitPrice)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));
            if (unitPrice == null) throw new ArgumentNullException(nameof(unitPrice));
            if (_lines.Count > 0 && _lines[0].UnitPrice.Currency != unitPrice.Currency)
                throw new InvalidOperationException("All lines must use the same currency.");

            var nextId = _lines.Count == 0 ? 1 : _lines[_lines.Count - 1].Id + 1;
            _lines.Add(new OrderLine(nextId, product, quantity, unitPrice));
        }
    }
}
