using App.Application.Auth.Command.GenerateAccessToken;
using App.Application.Auth.Command.SignIn;
using App.Application.Auth.Command.SignOut;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;
    public AuthController(IMediator mediator) => _mediator = mediator;


    /// <summary>
    /// Auth user with a specific params.
    /// </summary>
    /// <param name="command">Consumes user email and password.</param>
    /// <returns>Return an access and refresh token for a specific user.</returns>
    [HttpPost("sign-in")]
    public async Task<IActionResult> SignInAsync(SignInCommand command)
    {
        var result = await _mediator.Send(command);
        return result.Success ? Ok(result) : BadRequest(result);
    }


    /// <summary>
    /// Generates a new token with a specific token.
    /// </summary>
    /// <param name="command">Consumes a valid refreshToken.</param>
    /// <returns>Returns new token.</returns>
    [HttpGet("access-token")]
    public async Task<IActionResult> GenerateAccessTokenAsync([FromQuery] GenerateAccessTokenCommand command)
    {
        var result = await _mediator.Send(command);
        return result.Success ? Ok(result) : BadRequest(result);
    }


    /// <summary>
    /// Sign-out user with a specific token.
    /// </summary>
    /// <param name="command">Consume a valid refreshToken.</param>
    /// <returns>Return sign out result.</returns>
    [HttpPut("sign-out")]
    public async Task<IActionResult> SignOutAsync(SignOutCommand command)
    {
        var result = await _mediator.Send(command);
        return result.Success ? Ok(result) : BadRequest(result);
    }
}

