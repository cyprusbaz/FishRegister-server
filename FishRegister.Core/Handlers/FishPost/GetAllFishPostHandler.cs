using FishRegister.Core.Queries.FishPost;
using FishRegister.Domain.Dtos;
using FishRegister.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FishRegister.Core.Handlers.FishPost;

public class GetAllFishPostHandler : IRequestHandler<GellAllFishPostQuery, List<Domain.Entities.FishPost>>
{ 
    AppDbContext _context;

    public GetAllFishPostHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Domain.Entities.FishPost>> Handle(GellAllFishPostQuery request, CancellationToken cancellationToken)
    {
        Console.WriteLine(_context.FishPosts.ToListAsync().Result.Count);
        return await _context.FishPosts.ToListAsync(cancellationToken);
    }
}

