using App.Application.Address.Query.GetAll;
using App.Application.Client.Query.GetAll;
using App.Application.Client.Query.GetById;
using App.Application.Common.Responses;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers.v1;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class ClientController  : ApiControllerBase
{
    /// <summary>
    /// Retrives all app clients
    /// </summary>
    /// <returns>Lisr of app clients</returns>
    [ProducesResponseType(typeof(GenericResponse<List<GetAllAddressQuery>>), StatusCodes.Status200OK)]
    [HttpGet] 
    public async Task<IActionResult> GetAllAsync()
    {
        var res = await Mediator.Send(new GetAllClientQuery());
        return res.Success ? Ok(res) : BadRequest(res);
    }

    /// <summary>
    /// Retrieves client by its identifier
    /// </summary>
    /// <param name="query">Contains the client identifier</param>
    /// <returns>Returns the client details if found.</returns>
    [ProducesResponseType(typeof(GenericResponse<List<GetAllAddressQuery>>), StatusCodes.Status200OK)]
    [HttpGet("id/{id}")] 
    public async Task<IActionResult> GetByIdAsync([FromRoute]GetByIdClientQuery query)
    {
        var res = await Mediator.Send(query);
        return res.Success ? Ok(res) : BadRequest(res);
    }
}