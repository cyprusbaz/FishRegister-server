using MediatR;

namespace FishRegister.Core.Commands.User;

public class AuthenticateUserCommand : IRequest<Domain.Entities.User>
{
    public string username { get; set; }
    public string password { get; set; }
}