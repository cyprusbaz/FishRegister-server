using FishRegister.Core.Queries;
using FishRegister.Domain.Dtos;
using FishRegister.Domain.Entities;
using FishRegister.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FishRegister.Core.Handlers.Fishes;

public class GetFishByIdHandler : IRequestHandler<GetFishByIdQuery, FishDto>
{
    AppDbContext _context;

    public GetFishByIdHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<FishDto> Handle(GetFishByIdQuery request, CancellationToken cancellationToken)
    {
        var fish = await _context.Fishes.Where(f => f.Id == request.Id).Select(fs => new FishDto
        {
            Id = fs.Id,
            Name = fs.Name,
            Type = fs.Type,
        }).FirstOrDefaultAsync(cancellationToken);

        return fish ?? throw new NullReferenceException("Fish not found");
    }
}