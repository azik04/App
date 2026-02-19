using App.Application.Client.Query.GetAll;
using App.Application.Client.Query.GetById;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers;

[ApiController]
[ApiVersion("1.O")]
[Route("api/v{version:apiVersion}/Client")]
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
    
    
    [HttpGet("id/{id}")] 
    public async Task<IActionResult> GetByIdAsync([FromRoute]GetByIdClientQuery query)
    {
        var res = await _mediator.Send(query);
        return res.Success ? Ok(res) : BadRequest(res);
    }
}