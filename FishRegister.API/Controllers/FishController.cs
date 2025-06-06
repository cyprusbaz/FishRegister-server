using FishRegister.Core.Commands.Fishes;
using FishRegister.Core.Queries;
using Microsoft.AspNetCore.Mvc;

namespace FishRegister.API.Controllers;

public class FishController : BaseControlller
{
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll([FromQuery] GetAllFishQuery query)

    {
        var result = await Mediator.Send(query);
        return Ok(result);
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Create(CreateFishCommand command)
    {
        var result = await Mediator.Send(command);
        return Ok(result);
    }

    [HttpGet("GetById")]
    public async Task<IActionResult> GetById([FromQuery] GetFishByIdQuery query)
    {
        var result = await Mediator.Send(query);
        return Ok(result);
    }
}