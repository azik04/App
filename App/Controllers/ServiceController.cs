using App.Application.Services.Command.Create;
using App.Application.Services.Command.Delete;
using App.Application.Services.Query.GetAll;
using App.Application.User.Query.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ServiceController : ControllerBase
{
    private readonly IMediator _mediator;
    public ServiceController(IMediator mediator) => _mediator = mediator;

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateServiceCommand command)
    {
        var result = await _mediator.Send(command);
        return result.Success ? Ok(result) : BadRequest(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromRoute] GetAllServiceQuery query)
    {
        var result = await _mediator.Send(query);
        return result.Success ? Ok(result) : BadRequest(result);
    }

    [HttpDelete]
    public async Task<IActionResult> RemoveAll([FromQuery] DeleteServiceCommand command)
    {
        var result = await _mediator.Send(command);
        return result.Success ? Ok(result) : BadRequest(result);
    }
}
