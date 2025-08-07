using FishRegister.Core.Commands.FishPost;
using FishRegister.Core.Queries.FishPost;
using FishRegister.Core.Handlers.FishPost;
using Microsoft.AspNetCore.Mvc;

namespace FishRegister.API.Controllers;

public class FishPostController : BaseControlller
{
    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromForm]CreateFishPostCommand command)
    {
        var result = await Mediator.Send(command);

        return Ok(result);
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll([FromQuery]GellAllFishPostQuery command)
    {
        var result = await Mediator.Send(command);

        return Ok(result);
    }
    
}