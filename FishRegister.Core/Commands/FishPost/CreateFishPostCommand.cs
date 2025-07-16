using FishRegister.Domain.Entities;
using MediatR;

namespace FishRegister.Core.Commands.FishPost;

public class CreateFishPostCommand : IRequest<Guid>
{
    public required string Title { get; set; }
    public string? Content { get; set; }
    public required string Image { get; set; }
    public required Guid FishId { get; set; }
    public Guid UserId { get; set; }
}