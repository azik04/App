using App.Application.Address.Command.Create;
using App.Application.Address.Command.Delate;
using App.Application.Address.Command.Update;
using App.Application.Address.Query.GetAll;
using App.Application.Address.Query.GetById;
using App.Application.Common.Responses;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers.v1;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class AddressController : ApiControllerBase
{
    /// <summary>
    /// Create a new address for a specific client.
    /// </summary>
    /// <param name="command">Contains address creating data.</param>
    /// <returns>Returns create adress result</returns>
    [ProducesResponseType(typeof(GenericResponse<List<GetAllAddressQuery>>), StatusCodes.Status200OK)]
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateAddressCommand command)
    {
        var res = await Mediator.Send(command);
        return res.Success ? Ok(res) : BadRequest(res);
    }


    /// <summary>
    /// Retrieves all addresses associated with a specific worker.
    /// </summary>
    /// <param name="command">Contains the worker identifier.</param>
    /// <returns>Returns a list of addresses for the specified worker.</returns>
    [ProducesResponseType(typeof(GenericResponse<List<GetAllAddressQuery>>), StatusCodes.Status200OK)]
    [HttpGet("account/{appId}")]
    public async Task<IActionResult> GetAllAsync([FromRoute] GetAllAddressQuery command)
    {
        var res = await Mediator.Send(command);
        return res.Success ? Ok(res) : BadRequest(res);
    }


    /// <summary>
    /// Retrieves address with a specific identifier.
    /// </summary>
    /// <param name="command">Contains the address identifier.</param>
    /// <returns>Returns address with a specific identifier.</returns>
    [ProducesResponseType(typeof(GenericResponse<List<GetAllAddressQuery>>), StatusCodes.Status200OK)]
    [HttpGet("id/{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] GetByIdAddressQuery command)
    {
        var res = await Mediator.Send(command);
        return res.Success ? Ok(res) : BadRequest(res);
    }


    /// <summary>
    /// Remove an existin address with a specific identifier.
    /// </summary>
    /// <param name="command">Contains the address identifier.</param>
    /// <returns>Returns remove adress result</returns>
    [ProducesResponseType(typeof(GenericResponse<List<GetAllAddressQuery>>), StatusCodes.Status200OK)]
    [HttpDelete("id/{id}")]
    public async Task<IActionResult> RemoveAsync([FromRoute] DeleteAddressCommand command)
    {
        var res = await Mediator.Send(command);
        return res.Success ? Ok(res) : BadRequest(res);
    }


    /// <summary>
    /// Update an existin address with a specific identifier.
    /// </summary>
    /// <param name="command">Contains the address updating data.</param>
    /// <returns>Returns update adress result</returns>
    [ProducesResponseType(typeof(GenericResponse<List<GetAllAddressQuery>>), StatusCodes.Status200OK)]
    [HttpPut("id/{id}")]
    public async Task<IActionResult> UpdateAsunc([FromRoute]int id, [FromBody] UpdateAddressCommand request)
    {
        var command = new UpdateAddressCommand(
            id,
            request.Name,
            request.Lat,
            request.Lng,
            request.Address
        );

        var res = await Mediator.Send(command);
        return res.Success ? Ok(res) : BadRequest(res);
    }
}