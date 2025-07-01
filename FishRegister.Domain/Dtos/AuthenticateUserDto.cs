namespace FishRegister.Domain.Dtos;

public class AuthenticateUserDto
{
    public string AccessToken { get; set; }
    public Guid userID { get; set; }
}