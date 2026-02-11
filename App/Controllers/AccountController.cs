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


    [HttpPost("signup")]
    public async Task<IActionResult> SignUp(SignUpCommand command)
    {
        var result = await _mediator.Send(command);
        return result.Success ? Ok(result) : BadRequest(result);
    }

    [HttpPut("confirm")]
    public async Task<IActionResult> ConfirmEmail([FromQuery]ConfirmCommand command)
    {
        var result = await _mediator.Send(command);
        return result.Success ? Ok(result) : BadRequest(result);
    }

    [HttpPut("reset")]
    public async Task<IActionResult> ResetPassword(ResetCommand command)
    {
        var result = await _mediator.Send(command);
        return result.Success ? Ok(result) : BadRequest(result);
    }

    [HttpGet("send-confirm")]
    public async Task<IActionResult> SentConfirmEmail(SendConfirmCommand command)
    {
        var result = await _mediator.Send(command);
        return result.Success ? Ok(result) : BadRequest(result);
    }

    [HttpPut("change-password")]
    public async Task<IActionResult> ChangePasswordAsync(ChangePasswordCommand command)
    {
        var result = await _mediator.Send(command);
        return result.Success ? Ok(result) : BadRequest(result);
    }

    [HttpGet("send-reset")]
    public async Task<IActionResult> SentResetPassword(SendResetCommand command)
    {
        var result = await _mediator.Send(command);
        return result.Success ? Ok(result) : BadRequest(result);
    }
}
