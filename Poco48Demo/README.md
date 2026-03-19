
# Poco48Demo (.NET Framework 4.8)

Simple console app showing a **Full (rich) POCO** vs a **Flat POCO (DTO)**.

## Structure
- `Money.cs`, `Product.cs`, `Customer.cs`, `OrderLine.cs`, `Order.cs` — rich domain model
- `Dtos/OrderDto.cs`, `Dtos/OrderLineDto.cs` — flat DTOs
- `Mapper.cs` — mapping from domain to DTO
- `Program.cs` — entry point and console output
- `Poco48Demo.csproj` — SDK-style project targeting **net48**

## Build & Run
- Open in **Visual Studio 2019/2022** and run, **or**
- Using .NET SDK (6.0+ installed):
  ```bash
  dotnet build
  dotnet run --project Poco48Demo.csproj
  ```

> Note: SDK-style projects can target .NET Framework. Ensure the **.NET Framework 4.8 Developer Pack** is installed on the machine for compilation.
