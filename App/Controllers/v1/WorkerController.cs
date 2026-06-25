using App.Application.Common.DTO.Worker;
using App.Application.Common.Responses;
using App.Application.Worker.Query.GetById;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers.v1;

[ApiVersion("1.0")]
[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
public class WorkerController : ApiControllerBase
{
    /// <summary>
    /// Retrieves worker by its identifier
    /// </summary>
    /// <param name="query">Contains the worker identifier</param>
    /// <returns>Returns the worker details if found.</returns>
    [ProducesResponseType(typeof(GenericResponse<GetByIdWorkerDto>), StatusCodes.Status200OK)]
    [HttpGet("id/{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] GetByIdWorkerQuery query)
    {
        var res = await Mediator.Send(query);
        return res.Success ? Ok(res) : BadRequest(res);
    }
}