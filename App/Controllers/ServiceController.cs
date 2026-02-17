using App.Application.Services.Command.Create;
using App.Application.Services.Command.Delete;
using App.Application.Services.Query.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers;

[Route("api/v1/[controller]")]
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
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await _mediator.Send(new GetAllServiceQuery());
        return result.Success ? Ok(result) : BadRequest(result);
    }

    [HttpDelete("id/{id}")]
    public async Task<IActionResult> RemoveAll([FromRoute] DeleteServiceCommand command)
    {
        var result = await _mediator.Send(command);
        return result.Success ? Ok(result) : BadRequest(result);
    }
}
