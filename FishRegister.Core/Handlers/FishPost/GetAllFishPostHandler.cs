using FishRegister.Core.Queries.FishPost;
using FishRegister.Domain.Dtos;
using FishRegister.Domain.Entities;
using FishRegister.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FishRegister.Core.Handlers.FishPost;

public class GetAllFishPostHandler : IRequestHandler<GellAllFishPostQuery, List<FishPostDto>>
{ 
    AppDbContext _context;

    public GetAllFishPostHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<FishPostDto>> Handle(GellAllFishPostQuery request, CancellationToken cancellationToken)
    {
        
        var post = await _context.FishPosts.Select(Fp => new FishPostDto
        {
            Id = Fp.Id,
            Title = Fp.Title,
            Content = Fp.Content,
            Created = Fp.Created,
            //This might be problematic
            Fish = _context.Fishes.Select(f => new Fish
            {
                Id = f.Id,
                Name = f.Name,
                Type = f.Type
            }).Where(f => f.Id == Fp.FishId).FirstOrDefault(),
            Image = Fp.Image,
            UserId = Fp.UserId,
        }).AsNoTracking().ToListAsync(cancellationToken);

        return post;
    }
}

