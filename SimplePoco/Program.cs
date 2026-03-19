var customer = new Customer(1, "Contoso");  // full POCO with behavior and invariants
customer.Rename("Contoso Retail");          // behavior + invariant in the full POCO

var dto = new CustomerDto(customer);        // flat, serialization-friendly shape

Console.WriteLine("POCO Simple example");
Console.WriteLine($"CustomerDto: Id={dto.Id}, Name={dto.Name}");


// ===== FULL POCO (Rich Domain) =====
public sealed class Customer
{
    public int Id { get; private set; }
    public string Name { get; private set; }

    public Customer(int id, string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new System.ArgumentException("Name is required.", nameof(name));

        Id = id;
        Name = name;
    }

    // Domain behavior + invariant enforcement lives here
    public void Rename(string newName)
    {
        if (string.IsNullOrWhiteSpace(newName))
            throw new System.ArgumentException("New name is required.", nameof(newName));

        Name = newName.Trim();
    }
}

// ===== FLAT POCO (DTO) =====
// Data-only, no behavior—ideal for API responses, serialization, read models
public sealed class CustomerDto
{
    public int Id { get; set; }
    public string Name { get; set; }

    // Optional: convenience ctor to map from the domain entity
    public CustomerDto(Customer c)
    {
        Id = c.Id;
        Name = c.Name;
    }

    // Parameterless ctor for serializers if needed
    public CustomerDto() { }
}
