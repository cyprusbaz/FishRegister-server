using System.Runtime.InteropServices.JavaScript;
using FishRegister.Domain.Entities;

namespace FishRegister.Domain.Dtos;

public class FishPostDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string? Content { get; set; }
    public string Image { get; set; }
    public Fish Fish { get; set; }
    public DateTime Created { get; set; }
    public Guid UserId { get; set; }
}