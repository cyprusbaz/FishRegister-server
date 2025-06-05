using FishRegister.Core.Commands.Fishes;
using FishRegister.Domain.Entities;
using FishRegister.Infrastructure;
using MediatR;

namespace FishRegister.Core.Handlers.Fishes;

public class CreateFishHandler: IRequestHandler<CreateFishCommand, Guid>
{
    AppDbContext _dbContext;

    public CreateFishHandler(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Guid> Handle(CreateFishCommand request, CancellationToken cancellationToken)
    {
        var fish = new Domain.Entities.Fish
        {
            Name = request.Name,
            Type = request.Type,
        };
        await _dbContext.Fishes.AddAsync(fish, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        
        return fish.Id;
    }
}