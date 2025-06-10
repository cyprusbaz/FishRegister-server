using FishRegister.Domain.Entities;

namespace FishRegister.Domain.Dtos;

public class FishPostDto
{
    Guid Id { get; set; }
    public string Title { get; set; }
    public string? Content { get; set; }
    public string Image { get; set; }
    public Fish Fish { get; set; }
}