using App.Application.Address.Command.Delate;
using App.Application.Job.Command.Create;
using App.Application.Job.Command.Handle;
using App.Application.Job.Query.GetAllByClient;
using App.Application.Job.Query.GetAllByWorkerHistory;
using App.Application.Job.Query.GetById;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class JobController : ControllerBase
{
    private readonly IMediator _mediator;
    public JobController(IMediator mediator) => _mediator = mediator;


    /// <summary>
    /// Creates a new job.
    /// </summary>
    /// <param name="command">Contains data required to create a job.</param>
    /// <returns>Returns the result of the job creation operation.</returns>
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateJobCommand command)
    {
        var res = await _mediator.Send(command);
        return res.Success ? Ok(res) : BadRequest(res);
    }


    /// <summary>
    /// Retrieves all jobs associated with a specific client.
    /// </summary>
    /// <param name="command">Contains the client identifier.</param>
    /// <returns>Returns a list of jobs for the specified client.</returns>
    [HttpGet("client/{clientId}")]
    public async Task<IActionResult> GetAllClientAsync([FromRoute] GetAllByClientQuery command)
    {
        var res = await _mediator.Send(command);
        return res.Success ? Ok(res) : BadRequest(res);
    }


    /// <summary>
    /// Retrieves all jobs handled by a specific worker (job history).
    /// </summary>
    /// <param name="command">Contains the worker identifier.</param>
    /// <returns>Returns a list of jobs associated with the specified worker.</returns>
    [HttpGet("worker/{workerId}")]
    public async Task<IActionResult> GetAllWorkerAsync([FromRoute] GetAllByWorkerHistoryQuery command)
    {
        var res = await _mediator.Send(command);
        return res.Success ? Ok(res) : BadRequest(res);
    }


    /// <summary>
    /// Retrieves all jobs associated with a specific service.
    /// </summary>
    /// <param name="command">Contains the service identifier.</param>
    /// <returns>Returns a list of jobs for the specified service.</returns>
    [HttpGet("service/{serviceId}")]
    public async Task<IActionResult> GetAllByServiceAsync([FromRoute] GetAllByWorkerHistoryQuery command)
    {
        var res = await _mediator.Send(command);
        return res.Success ? Ok(res) : BadRequest(res);
    }


    /// <summary>
    /// Retrieves details of a job by its identifier.
    /// </summary>
    /// <param name="command">Contains the job identifier.</param>
    /// <returns>Returns the job details if found.</returns>
    [HttpGet("id/{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] GetByIdJobQuery command)
    {
        var res = await _mediator.Send(command);
        return res.Success ? Ok(res) : BadRequest(res);
    }


    /// <summary>
    /// Updates the status or handling information of a job.
    /// </summary>
    /// <param name="command">Contains data required to handle the job.</param>
    /// <returns>Returns the result of the job handling operation.</returns>
    [HttpPut("handle")]
    public async Task<IActionResult> HandleAsync([FromBody] HandleJobCommand command)
    {
        var res = await _mediator.Send(command);
        return res.Success ? Ok(res) : BadRequest(res);
    }


    /// <summary>
    /// Deletes a job or address by its identifier.
    /// </summary>
    /// <param name="command">Contains the identifier of the job or address to delete.</param>
    /// <returns>Returns the result of the delete operation.</returns>
    [HttpDelete("id/{id}")]
    public async Task<IActionResult> RemoveAsync([FromRoute] DeleteAddressCommand command)
    {
        var res = await _mediator.Send(command);
        return res.Success ? Ok(res) : BadRequest(res);
    }
}