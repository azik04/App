using App.Application.Account.Command.ChangePassword;
using App.Application.Account.Command.Confirm;
using App.Application.Account.Command.Reset;
using App.Application.Account.Command.SentConfirm;
using App.Application.Account.Command.SentReset;
using App.Application.Account.Command.SignUp;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IMediator _mediator;
    public AccountController(IMediator mediator) => _mediator = mediator;


    /// <summary>
    ///  Sign-Up User
    /// </summary>
    /// <param name="command">params</param>
    /// <returns></returns>
    [HttpPost("signup")]
    public async Task<IActionResult> SignUp(SignUpCommand command)
    {
        var result = await _mediator.Send(command);
        return result.Success ? Ok(result) : BadRequest(result);
    }

    
    /// <summary>
    /// Confirm user's email
    /// </summary>
    /// <param name="command">UserId</param>
    /// <returns></returns>
    [HttpPut("confirm")]
    public async Task<IActionResult> ConfirmEmail([FromQuery]ConfirmCommand command)
    {
        var result = await _mediator.Send(command);
        return result.Success ? Ok(result) : BadRequest(result);
    }

    
    /// <summary>
    /// Reset user's password
    /// </summary>
    /// <param name="command">datas</param>
    /// <returns></returns>
    [HttpPut("reset")]
    public async Task<IActionResult> ResetPassword(ResetCommand command)
    {
        var result = await _mediator.Send(command);
        return result.Success ? Ok(result) : BadRequest(result);
    }

    
    /// <summary>
    /// Sent's user confirmation email
    /// </summary>
    /// <param name="command">Email</param>
    /// <returns></returns>
    [HttpGet("send-confirm/{userId}")]
    public async Task<IActionResult> SentConfirmEmail([FromRoute] SendConfirmCommand command)
    {
        var result = await _mediator.Send(command);
        return result.Success ? Ok(result) : BadRequest(result);
    }

    /// <summary>
    /// Change user's password
    /// </summary>
    /// <param name="command">data</param>
    /// <returns></returns>
    [HttpPut("change-password")]
    public async Task<IActionResult> ChangePasswordAsync(ChangePasswordCommand command)
    {
        var result = await _mediator.Send(command);
        return result.Success ? Ok(result) : BadRequest(result);
    }

    
    /// <summary>
    /// Sent's user reset password email
    /// </summary>
    /// <param name="command">Email</param>
    /// <returns></returns>
    [HttpGet("send-reset/{email}")]
    public async Task<IActionResult> SentResetPassword([FromRoute] SendResetCommand command)
    {
        var result = await _mediator.Send(command);
        return result.Success ? Ok(result) : BadRequest(result);
    }
}
