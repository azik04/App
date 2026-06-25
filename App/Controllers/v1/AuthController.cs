using App.Application.Address.Query.GetAll;
using App.Application.Auth.Command.GenerateAccessToken;
using App.Application.Auth.Command.SignIn;
using App.Application.Auth.Command.SignOut;
using App.Application.Common.Responses;
using Asp.Versioning;
using Google.Apis.Auth;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers.v1;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class AuthController : ApiControllerBase
{
    /// <summary>
    /// Auth user with a specific params.
    /// </summary>
    /// <param name="command">Consumes user email and password.</param>
    /// <returns>Return an access and refresh token for a specific user.</returns>
    [ProducesResponseType(typeof(TokenResponse), StatusCodes.Status200OK)]
    [HttpPost("sign-in")]
    public async Task<IActionResult> SignInAsync(SignInCommand command)
    {
        var result = await Mediator.Send(command);
        return result.Success ? Ok(result) : BadRequest(result);
    }


    /// <summary>
    /// Generates a new token with a specific token.
    /// </summary>
    /// <param name="command">Consumes a valid refreshToken.</param>
    /// <returns>Returns new token.</returns>
    [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status200OK)]
    [HttpPost("access-token")]
    public async Task<IActionResult> GenerateAccessTokenAsync([FromBody] GenerateAccessTokenCommand command)
    {
        var result = await Mediator.Send(command);
        return result.Success ? Ok(result) : BadRequest(result);
    }


    /// <summary>
    /// Sign-out user with a specific token.
    /// </summary>
    /// <param name="command">Consume a valid refreshToken.</param>
    /// <returns>Return sign out result.</returns>
    [ProducesResponseType(typeof(GenericResponse<bool>), StatusCodes.Status200OK)]
    [HttpPut("sign-out")]
    public async Task<IActionResult> SignOutAsync(SignOutCommand command)
    {
        var result = await Mediator.Send(command);
        return result.Success ? Ok(result) : BadRequest(result);
    }
}

