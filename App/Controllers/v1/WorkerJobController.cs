using App.Application.Address.Query.GetAll;
using App.Application.Common.Responses;
using App.Application.WorkerJob.Command.Create;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers.v1;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class WorkerJobController : ApiControllerBase
{
    /// <summary>
    /// Assigns user to the job with a specific identifier.
    /// </summary>
    /// <param name="command">Consumes data required to create a workerJob.</param>
    /// <returns>Create service for a workerJob result.</returns>
    [ProducesResponseType(typeof(GenericResponse<bool>), StatusCodes.Status200OK)]
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateWorkerJobCommand command)
    {
        var result = await Mediator.Send(command);
        return result.Success ? Ok(result) : BadRequest(result);
    }
}
