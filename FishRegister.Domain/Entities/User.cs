namespace FishRegister.Domain.Entities;

public class User
{
    public Guid Id { get; set; } = new Guid();
    public required  string Username { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public required string Name { get; set; }
    public required string Surname { get; set; }
    List<FishPost>? fishPosts { get; set; } = new List<FishPost>();
}