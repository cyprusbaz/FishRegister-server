using System.IO.Pipelines;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using FishRegister.Core.Commands.FishPost;
using FishRegister.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Hosting;

namespace FishRegister.Core.Handlers.FishPost;

public class CreateFishPostHandler : IRequestHandler<CreateFishPostCommand, Guid>
{
    private AppDbContext _context;
    private readonly IWebHostEnvironment _env;

    public CreateFishPostHandler(AppDbContext context, IWebHostEnvironment env)
    {
        _context = context;
        _env = env;
    }

    public async Task<Guid> Handle(CreateFishPostCommand request, CancellationToken cancellationToken)
    {
        var image = request.Image;
        var name = image.Name;
        
        if (request.Image is null || request.Image.Length == 0)
        {
            throw new Exception("Image is empty");
        }
        var imageFolder = Path.Combine(_env.WebRootPath, "images");
        if (!Directory.Exists(imageFolder))
        {
            Directory.CreateDirectory(imageFolder);
        }
        var fileName = request.UserId + name + "file.jpg";
        var imagePath = Path.Combine(imageFolder, fileName);
        using (var fileStream = new FileStream(imagePath, FileMode.Create))
        {
            await request.Image.CopyToAsync(fileStream);
        }

        var post = new Domain.Entities.FishPost
        {
            UserId = request.UserId,
            Content = request.Content,
            Title = request.Title,
            Image = fileName,
            Created = DateTime.Now,
            FishId = request.FishId,
        };
        await _context.AddAsync(post, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        
        return post.Id;
    }
    
}