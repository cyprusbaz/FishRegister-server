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
    // private readonly IHttpContextAccessor _httpContextAccessor;

    public CreateFishPostHandler(AppDbContext context, IWebHostEnvironment env /*, IHttpContextAccessor httpContextAccessor*/)
    {
        _context = context;
        _env = env;
       //_httpContextAccessor = httpContextAccessor;
    }

    public async Task<Guid> Handle(CreateFishPostCommand request, CancellationToken cancellationToken)
    {
        var image = request.Image.FileName;
        
        if (request.Image is null || request.Image.Length == 0)
        {
            throw new Exception("Image is empty");
        }
        var imageFolder = Path.Combine(_env.WebRootPath, "images");
        if (!Directory.Exists(imageFolder))
        {
            Directory.CreateDirectory(imageFolder);
        }
        var fileName = request.UserId + image;
        var imagePath = Path.Combine(imageFolder, fileName);
        
        using (var fileStream = new FileStream(imagePath, FileMode.Create))
        {
            await request.Image.CopyToAsync(fileStream);
        };
        // if (_httpContextAccessor == null)
        // {
        //     throw new Exception("HttpContext is not available, http request context is required");
        // }
        //
        // var imageUrl = $"{_httpContextAccessor.HttpContext.Request.Protocol}://{_httpContextAccessor.HttpContext.Request.Host.Value}/{imagePath}";
        
        var post = new Domain.Entities.FishPost
        {
            UserId = request.UserId,
            Content = request.Content,
            Title = request.Title,
            Image = image,
            Created = DateTime.Now,
            FishId = request.FishId,
        };
        await _context.AddAsync(post, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        
        return post.Id;
    }
    
}