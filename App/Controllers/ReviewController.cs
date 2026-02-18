using App.Application.Reviews.Command.Create;
using App.Application.Reviews.Query.GetAll;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers;


[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class ReviewController : ControllerBase
{
    private readonly IMediator _mediator;
    public ReviewController(IMediator mediator) => _mediator = mediator;


    /// <summary>
    /// Creates a new review.
    /// </summary>
    /// <param name="command">Contains review creation data.</param>
    /// <returns>Returns the result of the review creation process.</returns>
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateReviewCommand command)
    {
        var res = await _mediator.Send(command);
        return res.Success ? Ok(res) : BadRequest(res);
    }


    /// <summary>
    /// Retrieves all reviews for a specific worker.
    /// </summary>
    /// <param name="command">Contains the worker identifier.</param>
    /// <returns>Returns a list of reviews associated with the specified worker.</returns>
    [HttpGet("worker/{workerId}")]
    public async Task<IActionResult> GetAllAsync([FromRoute] GetAllReviewQuery command)
    {
        var res = await _mediator.Send(command);
        return res.Success ? Ok(res) : BadRequest(res);
    }
}