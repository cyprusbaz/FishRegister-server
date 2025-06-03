using FishRegister.Core.Queries;
using Microsoft.AspNetCore.Mvc;

namespace FishRegister.API.Controllers;

public class FishController : BaseControlller
{
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll(GetAllFishQuery query)

    {
        var result = await Mediator.Send(query);
        return Ok(result);
    }
}