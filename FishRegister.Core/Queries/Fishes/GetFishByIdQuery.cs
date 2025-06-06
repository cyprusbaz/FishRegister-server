using FishRegister.Domain.Dtos;
using MediatR;

namespace FishRegister.Core.Queries;

public class GetFishByIdQuery : IRequest<FishDto>
{
    public required Guid Id { get; set; }
}