using FishRegister.Core.Commands.User;
using FishRegister.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FishRegister.Core.Handlers.User;

public class AuthenticateUserHandler : IRequestHandler<AuthenticateUserCommand, Domain.Entities.User>
{
    private AppDbContext _context;

    public AuthenticateUserHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Domain.Entities.User> Handle(AuthenticateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _context.Users.Where(user => user.Username == request.username && user.Password == request.password).FirstOrDefaultAsync(cancellationToken);
        
        return user ?? throw new NullReferenceException("No user found");
    }
}