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
using App.Application.Common.DTO.Account;
using App.Application.Common.Responses;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers.v1;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class AccountController : ApiControllerBase
{
    /// <summary>
    /// Retrieves all users by RoleId.
    /// </summary>
    /// <param name="query">Contains user's params.</param>
    /// <returns>Returns update result.</returns>
    [ProducesResponseType(typeof(PaginatedResponse<GetByIdAccount>), StatusCodes.Status200OK)]
    [HttpGet("get-all")]
    public async Task<IActionResult> GetAllAsync([FromQuery] GetAllAccountQuery query)
    {
        var result = await Mediator.Send(query);
        return result.Success ? Ok(result) : BadRequest(result);
    }


    /// <summary>
    /// Registers a new user.
    /// </summary>
    /// <param name="command">Contains user registration data.</param>
    /// <returns>Returns result of the registration process.</returns>
    [ProducesResponseType(typeof(GenericResponse<bool>), StatusCodes.Status200OK)]
    [HttpPost("sign-up")]
    public async Task<IActionResult> SignUp(SignUpCommand command)
    {
        var result = await Mediator.Send(command);
        return result.Success ? Ok(result) : BadRequest(result);
    }


    [HttpPost("add-role")]
    public async Task<IActionResult> AddRoleAsync()
    {
        var result = await Mediator.Send(new AddRoleCommand());
        return result.Success ? Ok(result) : BadRequest(result);
    }
    
    
    /// <summary>
    /// Sends a confirmation email
    /// </summary>
    /// <param name="command">Contains user's email</param>
    /// <returns>Returns confirm result</returns>
    [ProducesResponseType(typeof(GenericResponse<bool>), StatusCodes.Status200OK)]
    [HttpPost("send-mail")]
    public async Task<IActionResult> SentMailAsync([FromBody] SentMailCommand command)
    {
        var result = await Mediator.Send(command);
        return result.Success ? Ok(result) : BadRequest(result);
    }
    

    /// <summary>
    /// Sends a password reset email.
    /// </summary>
    /// <param name="command">Contains user's email address.</param>
    /// <returns>Returns email sending result.</returns>
    [ProducesResponseType(typeof(GenericResponse<bool>), StatusCodes.Status200OK)]
    [HttpPost("forget-password")]
    public async Task<IActionResult> SentResetPassword([FromBody] SendResetCommand command)
    {
        var result = await Mediator.Send(command);
        return result.Success ? Ok(result) : BadRequest(result);
    }


    /// <summary>
    /// Update user.
    /// </summary>
    /// <param name="command">Contains user's data.</param>
    /// <returns>Returns update result.</returns>
    [ProducesResponseType(typeof(GenericResponse<bool>), StatusCodes.Status200OK)]
    [HttpPut("id/{id}")]
    public async Task<IActionResult> Update(string id, [FromForm] UpdateAccountCommand command)
    {
        var result = await Mediator.Send(command with { id = id });
        return result.Success ? Ok(result) : BadRequest(result);
    }


    /// <summary>
    /// Confirms user's email address.
    /// </summary>
    /// <param name="command">Contains UserId and confirmation token.</param>
    /// <returns>Returns confirmation result.</returns>
    [ProducesResponseType(typeof(GenericResponse<bool>), StatusCodes.Status200OK)]
    [HttpPut("confirm-email")]
    public async Task<IActionResult> ConfirmEmail([FromBody]ConfirmEmailCommand command)
    {
        var result = await Mediator.Send(command);
        return result.Success ? Ok(result) : BadRequest(result);
    }


    /// <summary>
    /// Resets user's password.
    /// </summary>
    /// <param name="command">Contains reset token and new password.</param>
    /// <returns>Returns reset result.</returns>
    [ProducesResponseType(typeof(GenericResponse<bool>), StatusCodes.Status200OK)]
    [HttpPut("reset-password")]
    public async Task<IActionResult> ResetPassword(ResetPasswordCommand command)
    {
        var result = await Mediator.Send(command);
        return result.Success ? Ok(result) : BadRequest(result);
    }


    /// <summary>
    /// Changes user password.
    /// </summary>
    /// <param name="command">Contains current and new password.</param>
    /// <returns>Returns password change result.</returns>
    [ProducesResponseType(typeof(GenericResponse<bool>), StatusCodes.Status200OK)]
    [HttpPut("change-password")]
    public async Task<IActionResult> ChangePasswordAsync(ChangePasswordCommand command)
    {
        var result = await Mediator.Send(command);
        return result.Success ? Ok(result) : BadRequest(result);
    }


    /// <summary>
    /// Ban's user.
    /// </summary>
    /// <param name="command">Contains user's id.</param>
    /// <returns>Returns reset result.</returns>
    [ProducesResponseType(typeof(GenericResponse<bool>), StatusCodes.Status200OK)]
    [HttpPatch("id/{id}/ban-user")]
    public async Task<IActionResult> BanAsync([FromRoute]BanCommand command)
    {
        var result = await Mediator.Send(command);
        return result.Success ? Ok(result) : BadRequest(result);
    }
}
