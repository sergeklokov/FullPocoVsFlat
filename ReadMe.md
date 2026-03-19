
# Full Poco vs Flat DTO in C#

Console app showing **full POCO (rich domain)** vs **flat DTO** in C#.


POCO (Plain old CLR object, or plain old class object) is a simple object created in the .NET Common Language Runtime (CLR) that is unencumbered by inheritance or attributes. This is often used in opposition to the complex or specialized objects that object-relational mapping frameworks often require.[1] In essence, a POCO does not have any dependency on an external framework.

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
