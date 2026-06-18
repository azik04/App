using App.Application.Address.Command.Delate;
using App.Application.Address.Query.GetAll;
using App.Application.Common.Responses;
using App.Application.Job.Command.Create;
using App.Application.Job.Query.GetAllByWorker;
using App.Application.Job.Query.GetAllHandled;
using App.Application.Job.Query.GetById;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers.v1;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class JobController : ApiControllerBase
{
    /// <summary>
    /// Creates a new job.
    /// </summary>
    /// <param name="command">Contains data required to create a job.</param>
    /// <returns>Returns the result of the job creation operation.</returns>
    [ProducesResponseType(typeof(GenericResponse<List<GetAllAddressQuery>>), StatusCodes.Status200OK)]
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromForm] CreateJobCommand command)
    {
        var res = await Mediator.Send(command);
        return res.Success ? Ok(res) : BadRequest(res);
    }


    /// <summary>
    /// Retrieves all handled jobs.
    /// </summary>
    /// <param name="command">Contains the client identifier.</param>
    /// <returns>Returns a list of jobs for the specified client.</returns>
    [ProducesResponseType(typeof(GenericResponse<List<GetAllAddressQuery>>), StatusCodes.Status200OK)]
    [HttpGet("appId/{appId}/serviceId/{serviceId}")]
    public async Task<IActionResult> GetAllHandledAsync([FromRoute] GetAllHandledJobQuery command)
    {
        var res = await Mediator.Send(command);
        return res.Success ? Ok(res) : BadRequest(res);
    }


    /// <summary>
    /// Retrieves all jobs associated with a specific service.
    /// </summary>
    /// <param name="command">Contains the service identifier.</param>
    /// <returns>Returns a list of jobs for the specified service.</returns>
    [ProducesResponseType(typeof(GenericResponse<List<GetAllAddressQuery>>), StatusCodes.Status200OK)]
    [HttpGet("service/{serviceId}")]
    public async Task<IActionResult> GetAllActiveAsync([FromRoute] GetAllActiveJobQuery command)
    {
        var res = await Mediator.Send(command);
        return res.Success ? Ok(res) : BadRequest(res);
    }


    /// <summary>
    /// Retrieves details of a job by its identifier.
    /// </summary>
    /// <param name="command">Contains the job identifier.</param>
    /// <returns>Returns the job details if found.</returns>
    [ProducesResponseType(typeof(GenericResponse<List<GetAllAddressQuery>>), StatusCodes.Status200OK)]
    [HttpGet("id/{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] GetByIdJobQuery command)
    {
        var res = await Mediator.Send(command);
        return res.Success ? Ok(res) : BadRequest(res);
    }


    /// <summary>
    /// Deletes a job or address by its identifier.
    /// </summary>
    /// <param name="command">Contains the identifier of the job or address to delete.</param>
    /// <returns>Returns the result of the delete operation.</returns>
    [ProducesResponseType(typeof(GenericResponse<List<GetAllAddressQuery>>), StatusCodes.Status200OK)]
    [HttpDelete("id/{id}")]
    public async Task<IActionResult> RemoveAsync([FromRoute] DeleteAddressCommand command)
    {
        var res = await Mediator.Send(command);
        return res.Success ? Ok(res) : BadRequest(res);
    }
}