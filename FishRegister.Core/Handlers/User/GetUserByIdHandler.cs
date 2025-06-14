using FishRegister.Core.Queries.User;
using FishRegister.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FishRegister.Core.Handlers.User;

public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, Domain.Entities.User>
{
    private AppDbContext _context;

    public GetUserByIdHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Domain.Entities.User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == request.Id);
        
        return user ?? throw new NullReferenceException("User not found");
    }
}