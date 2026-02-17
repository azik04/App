using App.Application.Address.Command.Delate;
using App.Application.Job.Command.Create;
using App.Application.Job.Command.Handle;
using App.Application.Job.Query.GetAllByClient;
using App.Application.Job.Query.GetAllByWorkerHistory;
using App.Application.Job.Query.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class JobController : ControllerBase
{
    private readonly IMediator _mediator;
    public JobController(IMediator mediator) => _mediator = mediator;


    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateJobCommand command)
    {
        var res = await _mediator.Send(command);
        return res.Success ? Ok(res) : BadRequest(res);
    }
    
    [HttpGet("client/{clientId}")]
    public async Task<IActionResult> GetAllClientAsync([FromRoute] GetAllByClientQuery command)
    {
        var res = await _mediator.Send(command);
        return res.Success ? Ok(res) : BadRequest(res);
    }
    
    [HttpGet("worker/{workerId}")]
    public async Task<IActionResult> GetAllWorkerAsync([FromRoute] GetAllByWorkerHistoryQuery command)
    {
        var res = await _mediator.Send(command);
        return res.Success ? Ok(res) : BadRequest(res);
    }
    
    [HttpGet("service/{serviceId}")]
    public async Task<IActionResult> GetAllByServiceAsync([FromRoute] GetAllByWorkerHistoryQuery command)
    {
        var res = await _mediator.Send(command);
        return res.Success ? Ok(res) : BadRequest(res);
    }
    
    [HttpGet("id/{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] GetByIdJobQuery command)
    {
        var res = await _mediator.Send(command);
        return res.Success ? Ok(res) : BadRequest(res);
    }
    
    [HttpPut("handle")]
    public async Task<IActionResult> HandleAsync([FromBody] HandleJobCommand command)
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