using App.Application.Services.Command.Create;
using App.Application.Services.Command.Delete;
using App.Application.Services.Query.GetAll;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class ServiceController : ControllerBase
{
    private readonly IMediator _mediator;
    public ServiceController(IMediator mediator) => _mediator = mediator;


    /// <summary>
    /// Creates a new service.
    /// </summary>
    /// <param name="command">Contains service creation data.</param>
    /// <returns>Returns the result of the creation operation.</returns>
    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateServiceCommand command)
    {
        var result = await _mediator.Send(command);
        return result.Success ? Ok(result) : BadRequest(result);
    }


    /// <summary>
    /// Retrieves all services.
    /// </summary>
    /// <returns>Returns a list of all services.</returns>
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await _mediator.Send(new GetAllServiceQuery());
        return result.Success ? Ok(result) : BadRequest(result);
    }


    /// <summary>
    /// Deletes a service by its identifier.
    /// </summary>
    /// <param name="command">Contains the service identifier.</param>
    /// <returns>Returns the result of the delete operation.</returns>

    [HttpDelete("id/{id}")]
    public async Task<IActionResult> RemoveAll([FromRoute] DeleteServiceCommand command)
    {
        var result = await _mediator.Send(command);
        return result.Success ? Ok(result) : BadRequest(result);
    }
}
