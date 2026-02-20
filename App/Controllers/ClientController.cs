using App.Application.Client.Query.GetAll;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using App.Application.Client.Query.GetById;

namespace App.Controllers;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class ClientController  : ControllerBase
{
    private readonly IMediator _mediator;
    public ClientController(IMediator mediator) => _mediator = mediator;

    /// <summary>
    /// Retrives all app clients
    /// </summary>
    /// <returns>Lisr of app clients</returns>
    [HttpGet] 
    public async Task<IActionResult> GetAllAsync()
    {
        var res = await _mediator.Send(new GetAllClientQuery());
        return res.Success ? Ok(res) : BadRequest(res);
    }

    /// <summary>
    /// Retrieves client by its identifier
    /// </summary>
    /// <param name="query">Contains the client identifier</param>
    /// <returns>Returns the client details if found.</returns>
    [HttpGet("id/{id}")] 
    public async Task<IActionResult> GetByIdAsync([FromRoute]GetByIdClientQuery query)
    {
        var res = await _mediator.Send(query);
        return res.Success ? Ok(res) : BadRequest(res);
    }
}