using FishRegister.Core.Commands.FishPost;
using FishRegister.Domain.Dtos;
using FishRegister.Infrastructure;
using MediatR;

namespace FishRegister.Core.Handlers.FishPost;

public class CreateFishPostHandler : IRequestHandler<CreateFishPostCommand, Guid>
{
    private AppDbContext _context;

    public CreateFishPostHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateFishPostCommand request, CancellationToken cancellationToken)
    {
        var post = new Domain.Entities.FishPost
        {
            Content = request.Content,
            Title = request.Title,
            Image = request.Image,
            Fish = request.Fish,
        };
        await _context.AddAsync(post, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        
        return post.Id;
    }
}