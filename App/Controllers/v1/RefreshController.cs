using App.Application.Address.Query.GetAll;
using App.Application.Common.Responses;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers.v1;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class RefreshController : ApiControllerBase
{
    [ProducesResponseType(typeof(GenericResponse<List<GetAllAddressQuery>>), StatusCodes.Status200OK)]
    [HttpGet("statistics")]
    public async Task<IActionResult> GetAllAsync()
    {
        var res = await Mediator.Send(new Application.Refreshes.Query.GetAllRefreshCommand());
        return res.Success ? Ok(res) : BadRequest(res);
    }
}
