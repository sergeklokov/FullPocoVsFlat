using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullPocoVsFlat
{
    public static class Mapper
    {
        // Projection from full POCO to flat DTO
        public static OrderDto ToDto(Order o)
        {
            var lines = o.Lines.Select(l => new OrderLineDto(
                l.Product.Id,
                l.Product.Name,
                l.Quantity,
                l.UnitPrice.Amount,
                l.Subtotal.Amount
            )).ToList();

            return new OrderDto(
                o.Id,
                o.OrderDate,
                o.Customer.Id,
                o.Customer.Name,
                o.Total.Amount,
                lines
            );
        }
    }
}
