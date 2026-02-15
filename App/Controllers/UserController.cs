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

    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery]GetAllUserQuery query)
    {
        var result = await _mediator.Send(query);
        return result.Success ? Ok(result) : BadRequest(result);
    }
}