using App.Application.Address.Query.GetAll;
using App.Application.Common.Responses;
using App.Application.WorkerService.Command.Create;
using App.Application.WorkerService.Command.Delete;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class WorkerServiceController : ApiControllerBase
{
    /// <summary>
    /// Create new service for specific worker.
    /// </summary>
    /// <param name="command">Consumes userId and serviceId.</param>
    /// <returns>Create service for a user result.</returns>
    [ProducesResponseType(typeof(GenericResponse<bool>), StatusCodes.Status200OK)]
    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateWorkerServiceCommand command )
    {
        var result = await Mediator.Send(command);
        return result.Success ? Ok(result) : BadRequest(result);
    }


    /// <summary>
    /// Remove a worker's service with a specific identifier.
    /// </summary>
    /// <param name="command">Consumes a worker's service identifier.</param>
    /// <returns>Remove service for a user result.</returns>
    [ProducesResponseType(typeof(GenericResponse<bool>), StatusCodes.Status200OK)]
    [HttpDelete("id/{id}")]
    public async Task<IActionResult> RemoveAll([FromRoute] DeleteWorkerServiceCommand command)
    {
        var result = await Mediator.Send(command);
        return result.Success ? Ok(result) : BadRequest(result);
    }
}
