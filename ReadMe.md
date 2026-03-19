
# Full Poco vs Flat DTO in C#

Console app showing **full POCO (rich domain)** vs **flat DTO** in C#.


POCO (Plain old CLR object, or plain old class object) is a simple object created in the .NET Common Language Runtime (CLR) that is unencumbered by inheritance or attributes. This is often used in opposition to the complex or specialized objects that object-relational mapping frameworks often require. In essence, a POCO does not have any dependency on an external framework.
https://en.wikipedia.org/wiki/Plain_old_CLR_object

#class record
records are a language feature introduced in C# 9, designed to simplify the creation of immutable, data-centric types with value-based equality.  They are reference types that default to immutability and automatically generate essential members like Equals, GetHashCode, and ToString, reducing boilerplate code
https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/types/records


#interface IEquatable
IEquatable is a generic interface in C# that enables types to define a strongly-typed method for determining equality between instances.  By implementing IEquatable<T>, a class or struct provides a bool Equals(T other) method that compares two objects of the same type without requiring casting or boxing, improving performance—especially for value types.
https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1?view=net-10.0

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
