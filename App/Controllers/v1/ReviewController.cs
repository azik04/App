using App.Application.Address.Query.GetAll;
using App.Application.Common.Responses;
using App.Application.Reviews.Command.Create;
using App.Application.Reviews.Query.GetAll;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers.v1;


[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class ReviewController : ApiControllerBase
{
    /// <summary>
    /// Creates a new review.
    /// </summary>
    /// <param name="command">Contains review creation data.</param>
    /// <returns>Returns the result of the review creation process.</returns>
    [ProducesResponseType(typeof(GenericResponse<List<GetAllAddressQuery>>), StatusCodes.Status200OK)]
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateReviewCommand command)
    {
        var res = await Mediator.Send(command);
        return res.Success ? Ok(res) : BadRequest(res);
    }


    /// <summary>
    /// Retrieves all reviews for a specific worker.
    /// </summary>
    /// <param name="command">Contains the worker identifier.</param>
    /// <returns>Returns a list of reviews associated with the specified worker.</returns>
    [ProducesResponseType(typeof(GenericResponse<List<GetAllAddressQuery>>), StatusCodes.Status200OK)]
    [HttpGet("worker/{workerId}")]
    public async Task<IActionResult> GetAllAsync([FromRoute] GetAllReviewQuery command)
    {
        var res = await Mediator.Send(command);
        return res.Success ? Ok(res) : BadRequest(res);
    }
}