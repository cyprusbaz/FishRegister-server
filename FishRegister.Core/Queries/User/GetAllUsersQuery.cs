using FishRegister.Domain.Dtos;
using MediatR;

namespace FishRegister.Core.Queries.User;

public class GetAllUsersQuery : IRequest<List<UsersDto>>
{
    
}