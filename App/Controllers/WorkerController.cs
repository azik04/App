using App.Application.Worker.Query.GetAll;
using App.Application.Worker.Query.GetById;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers;

[ApiVersion("1.0")]
[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
public class WorkerController : ControllerBase
{
    private readonly IMediator _mediator;
    public WorkerController(IMediator mediator) => _mediator = mediator;

    /// <summary>
    /// Retrives all app workers
    /// </summary>
    /// <returns>Lisr of app workers</returns>
    [HttpGet] 
    public async Task<IActionResult> GetAllAsync()
    {
        var res = await _mediator.Send(new GetAllWorkerQuery());
        return res.Success ? Ok(res) : BadRequest(res);
    }


    /// <summary>
    /// Retrieves worker by its identifier
    /// </summary>
    /// <param name="query">Contains the worker identifier</param>
    /// <returns>Returns the worker details if found.</returns>
    [HttpGet("id/{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] GetByIdWorkerQuery query)
    {
        var res = await _mediator.Send(query);
        return res.Success ? Ok(res) : BadRequest(res);
    }
}