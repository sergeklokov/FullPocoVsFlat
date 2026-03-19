
# Full Poco vs Flat DTO in C#

Console app showing **full POCO (rich domain)** vs **flat DTO** in C#.

## Prereqs
- .NET SDK 8.0+

## Run
```bash
dotnet build
dotnet run
```

## What it shows
- Rich entities with behavior (Order, OrderLine, Money, Customer, Product)
- Flat DTOs (OrderDto, OrderLineDto)
- Mapping from POCO to DTO and a direct LINQ projection
