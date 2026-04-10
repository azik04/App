using App.Application.Account.Command.Ban;
using App.Application.Account.Command.ChangePassword;
using App.Application.Account.Command.ConfirmEmail;
using App.Application.Account.Command.ForgetPassword;
using App.Application.Account.Command.ResetPassword;
using App.Application.Account.Command.Role;
using App.Application.Account.Command.SentMail;
using App.Application.Account.Command.SignUp;
using App.Application.Account.Command.Update;
using App.Application.Account.Query.GetAll;
using App.Application.Account.Query.GetById;
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
    [HttpPost("sign-up")]
    public async Task<IActionResult> SignUp(SignUpCommand command)
    {
        var result = await _mediator.Send(command);
        return result.Success ? Ok(result) : BadRequest(result);
    }

    [HttpPost("add-role")]
    public async Task<IActionResult> AddRoleAsync()
    {
        var result = await _mediator.Send(new AddRoleCommand());
        return result.Success ? Ok(result) : BadRequest(result);
    }
    
    
    /// <summary>
    /// Sends a confirmation email
    /// </summary>
    /// <param name="command">Contains user's email</param>
    /// <returns>Returns confirm result</returns>
    [HttpPost("send-mail")]
    public async Task<IActionResult> SentMailAsync([FromBody] SentMailCommand command)
    {
        var result = await _mediator.Send(command);
        return result.Success ? Ok(result) : BadRequest(result);
    }
    

    /// <summary>
    /// Sends a password reset email.
    /// </summary>
    /// <param name="command">Contains user's email address.</param>
    /// <returns>Returns email sending result.</returns>
    [HttpPost("forget-password")]
    public async Task<IActionResult> SentResetPassword([FromBody] SendResetCommand command)
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
    public async Task<IActionResult> ConfirmEmail([FromBody]ConfirmEmailCommand command)
    {
        var result = await _mediator.Send(command);
        return result.Success ? Ok(result) : BadRequest(result);
    }


    /// <summary>
    /// Resets user's password.
    /// </summary>
    /// <param name="command">Contains reset token and new password.</param>
    /// <returns>Returns reset result.</returns>
    [HttpPut("reset-password")]
    public async Task<IActionResult> ResetPassword(ResetPasswordCommand command)
    {
        var result = await _mediator.Send(command);
        return result.Success ? Ok(result) : BadRequest(result);
    }


    /// <summary>
    /// Ban's user.
    /// </summary>
    /// <param name="command">Contains user's id.</param>
    /// <returns>Returns reset result.</returns>
    [HttpPatch("id/{id}")]
    public async Task<IActionResult> BanAsync([FromRoute]BanCommand command)
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


    /// <summary>
    /// Update user.
    /// </summary>
    /// <param name="command">Contains user's data.</param>
    /// <returns>Returns update result.</returns>
    [HttpPut("id/{id}")]
    public async Task<IActionResult> Update(string id, [FromForm] UpdateAccountCommand command)
    {
        var result = await _mediator.Send(command with { id = id });
        return result.Success ? Ok(result) : BadRequest(result);
    }

    /// <summary>
    /// Update user.
    /// </summary>
    /// <param name="command">Contains user's data.</param>
    /// <returns>Returns update result.</returns>
    [HttpGet("id/{id}")]
    public async Task<IActionResult> GetById([FromRoute] GetByIdQuery command)
    {
        var result = await _mediator.Send(command);
        return result.Success ? Ok(result) : BadRequest(result);
    }

    [HttpGet("get-all")]
    public async Task<IActionResult> GetAllAsync([FromQuery] GetAllAccountQuery query)
    {
        var result = await _mediator.Send(query);
        return result.Success ? Ok(result) : BadRequest(result);
    }
}
