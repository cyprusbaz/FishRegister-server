using FishRegister.Core.Commands.User;
using FishRegister.Domain.Configuration;
using FishRegister.Domain.Dtos;
using FishRegister.Infrastructure;
using FishRegister.Infrastructure.Services.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FishRegister.Core.Handlers.User;

public class AuthenticateUserHandler : IRequestHandler<AuthenticateUserCommand, AuthenticateUserDto>
{
    private readonly AppDbContext _context;
    private readonly IJwtService _jwtService;

    public AuthenticateUserHandler(AppDbContext context, IJwtService jwtService)
    {
        _context = context;
        _jwtService = jwtService;
    }

    public async Task<AuthenticateUserDto> Handle(AuthenticateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _context.Users.Where(user => user.Username == request.Username && user.Password == request.Password).FirstOrDefaultAsync(cancellationToken);

        if (user == null)
        {
            throw new UnauthorizedAccessException("no user found");
        }
        var token = new AuthenticateUserDto
        {
            userID = user.Id,
            AccessToken = _jwtService.GenerateJwtToken(user),
        };
        
        return token;
    }
}