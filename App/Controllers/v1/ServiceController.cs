using App.Application.Address.Query.GetAll;
using App.Application.Common.Responses;
using App.Application.Services.Command.Create;
using App.Application.Services.Command.Delete;
using App.Application.Services.Query.GetAll;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers.v1;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class ServiceController : ApiControllerBase
{
    /// <summary>
    /// Creates a new service.
    /// </summary>
    /// <param name="command">Contains service creation data.</param>
    /// <returns>Returns the result of the creation operation.</returns>
    [ProducesResponseType(typeof(GenericResponse<List<GetAllAddressQuery>>), StatusCodes.Status200OK)]
    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateServiceCommand command)
    {
        var result = await Mediator.Send(command);
        return result.Success ? Ok(result) : BadRequest(result);
    }


    /// <summary>
    /// Retrieves all services.
    /// </summary>
    /// <returns>Returns a list of all services.</returns>
    [ProducesResponseType(typeof(GenericResponse<List<GetAllAddressQuery>>), StatusCodes.Status200OK)]
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await Mediator.Send(new GetAllServiceQuery());
        return result.Success ? Ok(result) : BadRequest(result);
    }


    /// <summary>
    /// Deletes a service by its identifier.
    /// </summary>
    /// <param name="command">Contains the service identifier.</param>
    /// <returns>Returns the result of the delete operation.</returns>
    [ProducesResponseType(typeof(GenericResponse<List<GetAllAddressQuery>>), StatusCodes.Status200OK)]
    [HttpDelete("id/{id}")]
    public async Task<IActionResult> RemoveAll([FromRoute] DeleteServiceCommand command)
    {
        var result = await Mediator.Send(command);
        return result.Success ? Ok(result) : BadRequest(result);
    }
}
