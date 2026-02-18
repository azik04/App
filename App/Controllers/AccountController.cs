using App.Application.Account.Command.ChangePassword;
using App.Application.Account.Command.Confirm;
using App.Application.Account.Command.Reset;
using App.Application.Account.Command.SentConfirm;
using App.Application.Account.Command.SentReset;
using App.Application.Account.Command.SignUp;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IMediator _mediator;
    public AccountController(IMediator mediator) => _mediator = mediator;


    /// <summary>
    /// Registers a new user.
    /// </summary>
    /// <param name="command">Contains user registration data.</param>
    /// <returns>Returns result of the registration process.</returns>
    [HttpPost("signup")]
    public async Task<IActionResult> SignUp(SignUpCommand command)
    {
        var result = await _mediator.Send(command);
        return result.Success ? Ok(result) : BadRequest(result);
    }


    /// <summary>
    /// Sends a confirmation email
    /// </summary>
    /// <param name="command">Contains user's userId</param>
    /// <returns>Returns confirm result</returns>
    [HttpGet("send-confirm/{userId}")]
    public async Task<IActionResult> SentConfirmEmail([FromRoute] SendConfirmCommand command)
    {
        var result = await _mediator.Send(command);
        return result.Success ? Ok(result) : BadRequest(result);
    }


    /// <summary>
    /// Sends a password reset email.
    /// </summary>
    /// <param name="command">Contains user's email address.</param>
    /// <returns>Returns email sending result.</returns>
    [HttpGet("send-reset/{email}")]
    public async Task<IActionResult> SentResetPassword([FromRoute] SendResetCommand command)
    {
        var result = await _mediator.Send(command);
        return result.Success ? Ok(result) : BadRequest(result);
    }


    /// <summary>
    /// Confirms user's email address.
    /// </summary>
    /// <param name="command">Contains UserId and confirmation token.</param>
    /// <returns>Returns confirmation result.</returns>
    [HttpPut("confirm")]
    public async Task<IActionResult> ConfirmEmail([FromQuery]ConfirmCommand command)
    {
        var result = await _mediator.Send(command);
        return result.Success ? Ok(result) : BadRequest(result);
    }


    /// <summary>
    /// Resets user's password.
    /// </summary>
    /// <param name="command">Contains reset token and new password.</param>
    /// <returns>Returns reset result.</returns>
    [HttpPut("reset")]
    public async Task<IActionResult> ResetPassword(ResetCommand command)
    {
        var result = await _mediator.Send(command);
        return result.Success ? Ok(result) : BadRequest(result);
    }


    /// <summary>
    /// Changes user password.
    /// </summary>
    /// <param name="command">Contains current and new password.</param>
    /// <returns>Returns password change result.</returns>
    [HttpPut("change-password")]
    public async Task<IActionResult> ChangePasswordAsync(ChangePasswordCommand command)
    {
        var result = await _mediator.Send(command);
        return result.Success ? Ok(result) : BadRequest(result);
    }
}
