using System.Text.Json.Serialization;
using MediatR;
using FishRegister.Domain.Dtos;
namespace FishRegister.Core.Commands.User;

public class AuthenticateUserCommand : IRequest<AuthenticateUserDto>
{
    [JsonPropertyName("username")]
    public string Username { get; set; }
    [JsonPropertyName("password")]
    public string Password { get; set; }
}