
using System.Linq;

namespace Poco48Demo
{
    public static class Mapper
    {
        public static OrderDto ToDto(Order order)
        {
            if (order == null) return null;

            var lines = order.Lines
                .Select(l => new OrderLineDto
                {
                    ProductId = l.Product.Id,
                    ProductName = l.Product.Name,
                    Quantity = l.Quantity,
                    UnitPrice = l.UnitPrice.Amount,
                    Subtotal = l.Subtotal.Amount
                })
                .ToList();

            return new OrderDto
            {
                Id = order.Id,
                OrderDateUtc = order.OrderDateUtc,
                CustomerId = order.Customer.Id,
                CustomerName = order.Customer.Name,
                Total = order.Total.Amount,
                Lines = lines
            };
        }
    }
}
