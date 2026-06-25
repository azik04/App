using App.Application.Address.Query.GetAll;
using App.Application.Common.DTO.ContactUs;
using App.Application.Common.DTO.Refresh;
using App.Application.Common.Responses;
using App.Application.ContactUs.Query.GetById;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers.v1;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class RefreshController : ApiControllerBase
{
    /// <summary>
    /// Retrieves a daily sign in statistics.
    /// </summary>
    /// <returns>Returns a daily sign in statistics result.</returns>
    [ProducesResponseType(typeof(GenericResponse<List<GetAllRefreshDto>>), StatusCodes.Status200OK)]
    [HttpGet("statistics")]
    public async Task<IActionResult> GetAllAsync()
    {
        var res = await Mediator.Send(new Application.Refreshes.Query.GetAllRefreshCommand());
        return res.Success ? Ok(res) : BadRequest(res);
    }
}
