namespace FishRegister.Domain.Entities;

public class Fish
{
    public  Guid Id { get; set; } = Guid.NewGuid();
    public required string Name { get; set; }
    public required string Type { get; set; }
}