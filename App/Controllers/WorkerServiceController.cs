using App.Application.WorkerService.Command.Create;
using App.Application.WorkerService.Command.Delete;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class WorkerServiceController : ControllerBase
{
    private readonly IMediator _mediator;
    public WorkerServiceController(IMediator mediator) => _mediator = mediator;


    /// <summary>
    /// Create new service for specific worker.
    /// </summary>
    /// <param name="command">Consumes userId and serviceId.</param>
    /// <returns>Create service for a user result.</returns>
    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateWorkerServiceCommand command )
    {
        var result = await _mediator.Send(command);
        return result.Success ? Ok(result) : BadRequest(result);
    }


    /// <summary>
    /// Remove a worker's service with a specific identifier.
    /// </summary>
    /// <param name="command">Consumes a worker's service identifier.</param>
    /// <returns>Remove service for a user result.</returns>
    [HttpDelete("id/{id}")]
    public async Task<IActionResult> RemoveAll([FromRoute] DeleteWorkerServiceCommand command)
    {
        var result = await _mediator.Send(command);
        return result.Success ? Ok(result) : BadRequest(result);
    }
}
