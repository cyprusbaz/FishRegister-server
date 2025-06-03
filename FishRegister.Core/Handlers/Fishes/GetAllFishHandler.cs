using FishRegister.Core.Queries;
using FishRegister.Domain.Entities;
using FishRegister.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FishRegister.Core.Handlers.Fishes;

public class GetAllFishHandler(AppDbContext dbContext) : IRequestHandler<GetAllFishQuery, List<Fish>>
{
    public async Task<List<Fish>> Handle(GetAllFishQuery request, CancellationToken cancellationToken)
    {
        return await dbContext.Fishes.ToListAsync(cancellationToken);
    }
}