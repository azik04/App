using App.Application.Address.Command.Create;
using App.Application.Address.Command.Delate;
using App.Application.Address.Command.Update;
using App.Application.Address.Query.GetAll;
using App.Application.Address.Query.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class AddressController : Controller
{
    private readonly IMediator _mediator;
    public AddressController(IMediator mediator) => _mediator = mediator;


    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateAddressCommand command)
    {
        var res = await _mediator.Send(command);
        return res.Success ? Ok(res) : BadRequest(res);
    }
    
    [HttpGet("worker/{workerId}")]
    public async Task<IActionResult> GetAllAsync([FromRoute] GetAllAddressQuery command)
    {
        var res = await _mediator.Send(command);
        return res.Success ? Ok(res) : BadRequest(res);
    }
    
    [HttpGet("id/{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] GetByIdAddressQuery command)
    {
        var res = await _mediator.Send(command);
        return res.Success ? Ok(res) : BadRequest(res);
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateAsunc([FromBody] UpdateAddressCommand command)
    {
        var res = await _mediator.Send(command);
        return res.Success ? Ok(res) : BadRequest(res);
    }
    
    [HttpDelete("id/{id}")]
    public async Task<IActionResult> RemoveAsync([FromRoute] DeleteAddressCommand command)
    {
        var res = await _mediator.Send(command);
        return res.Success ? Ok(res) : BadRequest(res);
    }
}