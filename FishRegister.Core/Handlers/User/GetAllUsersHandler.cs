using FishRegister.Core.Queries.User;
using FishRegister.Domain.Dtos;
using FishRegister.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FishRegister.Core.Handlers.User;

public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, List<UsersDto>>
{
    private AppDbContext _context;

    public GetAllUsersHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<UsersDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await _context.Users.Select(user => new UsersDto
        {
            Name = user.Name,
            Surname = user.Surname,
            UserId = user.Id,
        }).AsNoTracking().ToListAsync(cancellationToken);
        
        return users;
    }
}