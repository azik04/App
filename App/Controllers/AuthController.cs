using App.Application.Auth.Command.GenerateAccessToken;
using App.Application.Auth.Command.SignIn;
using App.Application.Auth.Command.SignOut;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;
    public AuthController(IMediator mediator) => _mediator = mediator;


    [HttpPost("sign-in")]
    public async Task<IActionResult> SignInAsync(SignInCommand command)
    {
        var result = await _mediator.Send(command);
        return result.Success ? Ok(result) : BadRequest(result);
    }
    
    [HttpPut("sign-out")]
    public async Task<IActionResult> SignOutAsync(SignOutCommand command)
    {
        var result = await _mediator.Send(command);
        return result.Success ? Ok(result) : BadRequest(result);
    }
    
    [HttpGet("access-token")]
    public async Task<IActionResult> GenerateAccessTokenAsync(GenerateAccessTokenCommand command)
    {
        var result = await _mediator.Send(command);
        return result.Success ? Ok(result) : BadRequest(result);
    }
}

