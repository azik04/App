using App.Application.Auth.Command.GenerateAccessToken;
using App.Application.Auth.Command.SignIn;
using App.Application.Auth.Command.SignOut;
using Asp.Versioning;
using Google.Apis.Auth;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

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

    [HttpPost("google")]
    public async Task<IActionResult> SignInAsync([FromForm] string token)
    {
        if (string.IsNullOrEmpty(token))
            return BadRequest(new { error = "Token is required" });

        var settings = new GoogleJsonWebSignature.ValidationSettings
        {
            Audience = new[] { "641553983301-n4knggtg5vua9ivtimgjkbubrcrjo7j3.apps.googleusercontent.com" }
        };

        var payload = await GoogleJsonWebSignature.ValidateAsync(token, settings);

        return Ok(new { success = true, user = payload });
    }


    /// <summary>
    /// Generates a new token with a specific token.
    /// </summary>
    /// <param name="command">Consumes a valid refreshToken.</param>
    /// <returns>Returns new token.</returns>
    [HttpPost("access-token")]
    public async Task<IActionResult> GenerateAccessTokenAsync([FromBody] GenerateAccessTokenCommand command)
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

