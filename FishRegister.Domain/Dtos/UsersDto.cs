using FishRegister.Domain.Entities;

namespace FishRegister.Domain.Dtos;

public class UsersDto
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public Guid UserId { get; set; }
    
    
}