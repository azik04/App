using App.Application.Services.Command.Create;
using App.Application.Services.Command.Delete;
using App.Application.Services.Query.GetAll;
using App.Application.WorkerService.Command.Create;
using App.Application.WorkerService.Command.Delete;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class WorkerServiceController : ControllerBase
{
    private readonly IMediator _mediator;
    public WorkerServiceController(IMediator mediator) => _mediator = mediator;

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateWorkerServiceCommand command)
    {
        var result = await _mediator.Send(command);
        return result.Success ? Ok(result) : BadRequest(result);
    }

    [HttpDelete("id/{id}")]
    public async Task<IActionResult> RemoveAll([FromRoute] DeleteWorkerServiceCommand command)
    {
        var result = await _mediator.Send(command);
        return result.Success ? Ok(result) : BadRequest(result);
    }
}
