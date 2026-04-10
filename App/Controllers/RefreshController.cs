using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class RefreshController : ControllerBase
{
    private readonly IMediator _mediator;
    public RefreshController(IMediator mediator) => _mediator = mediator;

    [HttpGet("statistics")]
    public async Task<IActionResult> GetAllAsync()
    {
        var res = await _mediator.Send(new App.Application.Refreshes.Query.GetAllRefreshCommand());
        return res.Success ? Ok(res) : BadRequest(res);
    }
}
