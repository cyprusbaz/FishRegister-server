using MediatR;
using FishRegister.Domain.Dtos;
namespace FishRegister.Core.Commands.User;

public class AuthenticateUserCommand : IRequest<AuthenticateUserDto>
{
    public string Username { get; set; }
    public string Password { get; set; }
}