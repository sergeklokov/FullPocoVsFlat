
using System;
using System.Collections.Generic;

namespace Poco48Demo
{
    public sealed class OrderDto
    {
        public int Id { get; set; }
        public DateTime OrderDateUtc { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public decimal Total { get; set; }
        public List<OrderLineDto> Lines { get; set; }
    }
}
