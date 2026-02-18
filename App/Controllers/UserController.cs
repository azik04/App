using App.Application.User.Query.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class UserController : Controller
{
    private readonly IMediator _mediator;
    public UserController(IMediator mediator) => _mediator = mediator;


    /// <summary>
    /// Retrieves address with a specific role.
    /// </summary>
    /// <param name="role">Consume a user role.</param>
    /// <returns>Returns a list of users for the specified role.</returns>
    [HttpGet("role")]
    public async Task<IActionResult> GetAllAsync([FromQuery] GetAllUserQuery query)
    {
        var result = await _mediator.Send(query);
        return result.Success ? Ok(result) : BadRequest(result);
    }
}