using FishRegister.Domain.Entities;

namespace FishRegister.Infrastructure.Services.Interfaces;

public interface IJwtService
{
    public string GenerateJwtToken(User user);
}