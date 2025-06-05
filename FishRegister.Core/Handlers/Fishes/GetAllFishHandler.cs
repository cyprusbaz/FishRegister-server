using FishRegister.Core.Queries;
using FishRegister.Domain.Entities;
using FishRegister.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FishRegister.Core.Handlers.Fishes;

public class GetAllFishHandler : IRequestHandler<GetAllFishQuery, List<Fish>>
{
    AppDbContext context;

    public GetAllFishHandler(AppDbContext context)
    {
        this.context = context;
    }

    public async Task<List<Fish>> Handle(GetAllFishQuery request, CancellationToken cancellationToken)
    {
        return await context.Fishes.ToListAsync(cancellationToken);
    }
}