using MediatR;

namespace FishRegister.Core.Commands.Fishes;

public class CreateFishCommand : IRequest<Guid>
{
    public string Name { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
}