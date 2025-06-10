using FishRegister.Core.Commands.FishPost;
using Microsoft.AspNetCore.Mvc;

namespace FishRegister.API.Controllers;

public class FishPostController : BaseControlller
{
    [HttpPost("Create")]
    public async Task<IActionResult> Create(CreateFishPostCommand commnad)
    {
        var result = await Mediator.Send(commnad);

        return Ok(result);
    }
}