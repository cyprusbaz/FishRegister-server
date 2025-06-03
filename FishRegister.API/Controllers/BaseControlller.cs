using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FishRegister.API.Controllers;


[ApiController]
[Route("api/[controller]")]
public class BaseControlller : ControllerBase
{
    private IMediator? _mediator;

    protected IMediator Mediator
        => (_mediator ??= HttpContext.RequestServices.GetService<IMediator>()) ?? throw new ArgumentNullException(nameof(_mediator));
}