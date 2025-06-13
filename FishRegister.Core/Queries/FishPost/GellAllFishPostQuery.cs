using FishRegister.Domain.Dtos;
using MediatR;

namespace FishRegister.Core.Queries.FishPost;

public class GellAllFishPostQuery : IRequest<List<FishPostDto>>
{
    
}