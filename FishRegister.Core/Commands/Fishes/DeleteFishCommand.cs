using FishRegister.Domain.Dtos;
using FishRegister.Domain.Entities;
using MediatR;

namespace FishRegister.Core.Commands.Fishes;

public class DeleteFishCommand : IRequest<FishDto>
{
    public Guid Id { get; set; }
}