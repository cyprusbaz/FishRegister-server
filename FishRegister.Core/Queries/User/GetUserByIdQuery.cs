using MediatR;

namespace FishRegister.Core.Queries.User;

public class GetUserByIdQuery : IRequest<Domain.Entities.User>
{
    public Guid Id { get; set; }
}