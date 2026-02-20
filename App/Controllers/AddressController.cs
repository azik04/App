using App.Application.Address.Command.Create;
using App.Application.Address.Command.Delate;
using App.Application.Address.Command.Update;
using App.Application.Address.Query.GetAll;
using App.Application.Address.Query.GetById;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class AddressController : Controller
{
    private readonly IMediator _mediator;
    public AddressController(IMediator mediator) => _mediator = mediator;


    /// <summary>
    /// Create a new address for a specific client.
    /// </summary>
    /// <param name="command">Contains address creating data.</param>
    /// <returns>Returns create adress result</returns>
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateAddressCommand command)
    {
        var res = await _mediator.Send(command);
        return res.Success ? Ok(res) : BadRequest(res);
    }


    /// <summary>
    /// Retrieves all addresses associated with a specific worker.
    /// </summary>
    /// <param name="command">Contains the worker identifier.</param>
    /// <returns>Returns a list of addresses for the specified worker.</returns>
    [HttpGet("client/{clientId}")]
    public async Task<IActionResult> GetAllAsync([FromRoute] GetAllAddressQuery command)
    {
        var res = await _mediator.Send(command);
        return res.Success ? Ok(res) : BadRequest(res);
    }


    /// <summary>
    /// Retrieves address with a specific identifier.
    /// </summary>
    /// <param name="command">Contains the address identifier.</param>
    /// <returns>Returns address with a specific identifier.</returns>
    [HttpGet("id/{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] GetByIdAddressQuery command)
    {
        var res = await _mediator.Send(command);
        return res.Success ? Ok(res) : BadRequest(res);
    }


    /// <summary>
    /// Remove an existin address with a specific identifier.
    /// </summary>
    /// <param name="command">Contains the address identifier.</param>
    /// <returns>Returns remove adress result</returns>
    [HttpDelete("id/{id}")]
    public async Task<IActionResult> RemoveAsync([FromRoute] DeleteAddressCommand command)
    {
        var res = await _mediator.Send(command);
        return res.Success ? Ok(res) : BadRequest(res);
    }


    /// <summary>
    /// Update an existin address with a specific identifier.
    /// </summary>
    /// <param name="command">Contains the address updating data.</param>
    /// <returns>Returns update adress result</returns>
    [HttpPut("id/{id}")]
    public async Task<IActionResult> UpdateAsunc([FromRoute]int id, [FromBody] UpdateAddressRequest request)
    {
        var command = new UpdateAddressCommand(
            id,
            request.Name,
            request.X,
            request.Y,
            request.Address
        );

        var res = await _mediator.Send(command);
        return res.Success ? Ok(res) : BadRequest(res);
    }
}