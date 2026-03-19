using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullPocoVsFlat
{
    public class Order
    {
        private readonly List<OrderLine> _lines = new();

        public int Id { get; private set; }
        public DateOnly OrderDate { get; private set; }
        public Customer Customer { get; private set; }
        public IReadOnlyCollection<OrderLine> Lines => _lines.AsReadOnly();
        public Money Total => new(_lines.Sum(l => l.Subtotal.Amount), _lines.FirstOrDefault()?.UnitPrice.Currency ?? "USD");

        private Order() { Customer = new Customer(0, string.Empty); }
        public Order(int id, Customer customer, DateOnly orderDate)
        {
            Id = id;
            Customer = customer ?? throw new ArgumentNullException(nameof(customer));
            OrderDate = orderDate;
        }

        public void AddLine(Product product, int quantity, Money unitPrice)
        {
            var nextId = _lines.Count == 0 ? 1 : _lines.Max(l => l.Id) + 1;
            _lines.Add(new OrderLine(nextId, product, quantity, unitPrice));
        }
    }
}
