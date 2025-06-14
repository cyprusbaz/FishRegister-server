using FishRegister.Core.Commands.User;
using FishRegister.Infrastructure;
using MediatR;

namespace FishRegister.Core.Handlers.User;

public class CreateUserHandler : IRequestHandler<CreateUserCommand, Guid>
{
    AppDbContext context;

    public CreateUserHandler(AppDbContext context)
    {
        this.context = context;
    }

    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new Domain.Entities.User
        {
            Username = request.Username,
            Email = request.Email,
            Password = request.Password,
            Name = request.Name,
            Surname = request.Surname,
        };
        
        await context.Users.AddAsync(user, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return user.Id;
    }
}