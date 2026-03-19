
using System;
using System.Collections.Generic;
using System.Linq;
using FullPocoVsFlat;

// ===== Flat DTOs =====
//public record OrderLineDto(int ProductId, string ProductName, int Quantity, decimal UnitPrice, decimal Subtotal);
//public record OrderDto(int Id, DateOnly OrderDate, int CustomerId, string CustomerName, decimal Total, IReadOnlyList<OrderLineDto> Lines);

Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.WriteLine("=== POCO vs Flat DTO Demo ===");

// Seed in-memory objects (no EF in this console app)
var cust = new Customer(1, "Contoso Retail");
var p1 = new Product(10, "USB-C Cable");
var p2 = new Product(11, "65W Charger");

// Create a full POCO (rich) aggregate
var order = new Order(1001, cust, DateOnly.FromDateTime(DateTime.UtcNow));
order.AddLine(p1, quantity: 2, unitPrice: new Money(8.99m, "USD"));
order.AddLine(p2, quantity: 1, unitPrice: new Money(29.99m, "USD"));

// Show behavior available on full POCO
PrintFull(order);

// Project to flat DTO for serialization / API shape / read models
var dto = Mapper.ToDto(order);
PrintFlat(dto);

// Example of projecting via LINQ directly (like EF Select)
var projected = new OrderDto(
    order.Id,
    order.OrderDate,
    order.Customer.Id,
    order.Customer.Name,
    order.Lines.Sum(l => l.Subtotal.Amount),
    order.Lines.Select(l => new OrderLineDto(
        l.Product.Id,
        l.Product.Name,
        l.Quantity,
        l.UnitPrice.Amount,
        l.Subtotal.Amount
    )).ToList()
);

Console.WriteLine("--- Projection via LINQ (simulating EF .Select) ---");
Console.WriteLine($"Total (projected): {projected.Total:0.00}");

static void PrintFull(Order order)
{
    Console.WriteLine("--- Full POCO (Rich Domain) ---");
    Console.WriteLine($"Order #{order.Id} on {order.OrderDate:yyyy-MM-dd}");
    Console.WriteLine($"Customer: {order.Customer.Name}");
    foreach (var l in order.Lines)
    {
        Console.WriteLine($"  - {l.Product.Name} x{l.Quantity} @ {l.UnitPrice} = {l.Subtotal}");
    }
    Console.WriteLine($"Total: {order.Total}");
}

static void PrintFlat(OrderDto dto)
{
    Console.WriteLine("--- Flat DTO ---");
    Console.WriteLine($"Order #{dto.Id} on {dto.OrderDate:yyyy-MM-dd}");
    Console.WriteLine($"Customer: {dto.CustomerName} (Id: {dto.CustomerId})");
    foreach (var l in dto.Lines)
    {
        Console.WriteLine($"  - {l.ProductName} x{l.Quantity} @ {l.UnitPrice:0.00} = {l.Subtotal:0.00}");
    }
    Console.WriteLine($"Total: {dto.Total:0.00}");
}
