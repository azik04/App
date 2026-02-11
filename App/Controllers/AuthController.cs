using App.Application.Auth.Command.Auth;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;
    public AuthController(IMediator mediator) => _mediator = mediator;


    [HttpPost]
    public async Task<IActionResult> Auth(AuthCommand command)
    {
        var result = await _mediator.Send(command);
        
        if (!result.Success)
            return BadRequest(result);

        return Ok(result);
    }
}

