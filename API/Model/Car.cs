using System;

namespace API.Model;

public class Car
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string Name { get; set; }
    public required decimal Price { get; set; }
    public required string Model { get; set; }
    public DateOnly Year { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow.AddHours(7);
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow.AddHours(7);
}
