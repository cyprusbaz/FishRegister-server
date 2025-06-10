namespace FishRegister.Domain.Entities;

public class FishPost
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string Title { get; set; }
    public string? Content { get; set; }
    public required string Image { get; set; }
    public required Fish Fish { get; set; }
    public required DateTime Created { get; set; } = DateTime.Now;
    public required Guid UserId { get; set; }
}