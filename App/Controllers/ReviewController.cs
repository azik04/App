using App.Application.Reviews.Command.Create;
using App.Application.Reviews.Query.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class ReviewController : ControllerBase
{
    private readonly IMediator _mediator;
    public ReviewController(IMediator mediator) => _mediator = mediator;


    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateReviewCommand command)
    {
        var res = await _mediator.Send(command);
        return res.Success ? Ok(res) : BadRequest(res);
    }
    
    [HttpGet("worker/{workerId}")]
    public async Task<IActionResult> GetAllAsync([FromRoute] GetAllReviewQuery command)
    {
        var res = await _mediator.Send(command);
        return res.Success ? Ok(res) : BadRequest(res);
    }
}