using FishRegister.Core.Commands.User;
using FishRegister.Core.Queries.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FishRegister.API.Controllers;

public class UserController : BaseControlller
{
    [AllowAnonymous]
    [HttpPost("Register")]
    public async Task<IActionResult> Create(CreateUserCommand command)
    {
        var result = await Mediator.Send(command);
        return Ok(result);
    }

    [HttpGet("Get")]
    public async Task<IActionResult> Get([FromQuery]GetUserByIdQuery query)
    {
        var result = await Mediator.Send(query);
        return Ok(result);
    }
    
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll([FromQuery]GetAllUsersQuery query)
    {
        var result = await Mediator.Send(query);
        return Ok(result);
    }
    [AllowAnonymous]
    [HttpPost("Login")]
    public async Task<IActionResult> AutheticateUser([FromBody] AuthenticateUserCommand command)
    {
        var result = await Mediator.Send(command);
        return Ok(result);
    }
}