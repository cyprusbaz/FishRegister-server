using FishRegister.Core.Commands.Fishes;
using FishRegister.Domain.Dtos;
using FishRegister.Domain.Entities;
using FishRegister.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FishRegister.Core.Handlers.Fishes;

public class DeleteFishHandler : IRequestHandler<DeleteFishCommand, FishDto>
{
    private AppDbContext _context;
    private IRequestHandler<DeleteFishCommand, FishDto> _requestHandlerImplementation;

    public DeleteFishHandler(AppDbContext context)
    {
        _context = context;
    }


    public async Task<FishDto> Handle(DeleteFishCommand request, CancellationToken cancellationToken)
    {
        
        var fishToDelete = await _context.Fishes.Where(fish => fish.Id == request.Id).FirstOrDefaultAsync(cancellationToken);
        var fishToReturn = await _context.Fishes.Select(fish => new FishDto
        {
          Id = fish.Id,
          Name = fish.Name,
          Type = fish.Type,
        }).Where(fish => fish.Id == request.Id).FirstOrDefaultAsync(cancellationToken);

        if (fishToDelete != null)
        {
            _context.Fishes.Remove(fishToDelete);
            await _context.SaveChangesAsync(cancellationToken);
        }
        
        return fishToReturn ?? throw new NullReferenceException("Did not find a fish to delete");
    }
}