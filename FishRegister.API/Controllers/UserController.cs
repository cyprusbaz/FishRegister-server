using FishRegister.Core.Queries.User;
using Microsoft.AspNetCore.Mvc;

namespace FishRegister.API.Controllers;

public class UserController : BaseControlller
{
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll([FromQuery]GetAllUsersQuery query)
    {
        var result = await Mediator.Send(query);
        return Ok(result);
    }
}