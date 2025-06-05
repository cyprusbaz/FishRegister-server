using FishRegister.Domain.Entities;
using MediatR;

namespace FishRegister.Core.Queries;

public class GetAllFishQuery : IRequest<List<Fish>>
{
}