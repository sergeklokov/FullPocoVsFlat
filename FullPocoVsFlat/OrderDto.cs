using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullPocoVsFlat
{
    public record OrderDto(int Id, DateOnly OrderDate, int CustomerId, string CustomerName, decimal Total, IReadOnlyList<OrderLineDto> Lines);
}
