
    using System;

    namespace Poco48Demo
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("=== .NET Framework 4.8 — Full POCO vs Flat DTO ===");

                var customer = new Customer(1, "Contoso Retail");
                var p1 = new Product(10, "USB-C Cable");
                var p2 = new Product(11, "65W Charger");

                var order = new Order(1001, customer, DateTime.UtcNow);
                order.AddLine(p1, 2, new Money(8.99m, "USD"));
                order.AddLine(p2, 1, new Money(29.99m, "USD"));

                PrintFull(order);

                var dto = Mapper.ToDto(order);
                PrintFlat(dto);

                Console.WriteLine("Done. Press any key to exit...");
                Console.ReadKey();
            }

            private static void PrintFull(Order order)
            {
                Console.WriteLine("--- Full POCO (Rich Domain) ---");
                Console.WriteLine($"Order #{order.Id} at {order.OrderDateUtc:u}");
                Console.WriteLine($"Customer: {order.Customer.Name}");
                foreach (var l in order.Lines)
                {
                    Console.WriteLine($"  - {l.Product.Name} x{l.Quantity} @ {l.UnitPrice} = {l.Subtotal}");
                }
                Console.WriteLine($"Total: {order.Total}");
            }

            private static void PrintFlat(OrderDto dto)
            {
                Console.WriteLine("--- Flat DTO ---");
                Console.WriteLine($"Order #{dto.Id} at {dto.OrderDateUtc:u}");
                Console.WriteLine($"Customer: {dto.CustomerName} (Id: {dto.CustomerId})");
                foreach (var l in dto.Lines)
                {
                    Console.WriteLine($"  - {l.ProductName} x{l.Quantity} @ {l.UnitPrice:0.00} = {l.Subtotal:0.00}");
                }
                Console.WriteLine($"Total: {dto.Total:0.00}");
            }
        }
    }
