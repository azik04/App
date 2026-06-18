using App.Application.Address.Query.GetAll;
using App.Application.Common.Responses;
using App.Application.ContactUs.Command;
using App.Application.ContactUs.Query.GetAll;
using App.Application.ContactUs.Query.GetById;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers.v1;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class ContactUsController : ApiControllerBase
{
    [ProducesResponseType(typeof(GenericResponse<List<GetAllAddressQuery>>), StatusCodes.Status200OK)]
    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateContactUsCommand command)
    {
        var res = await Mediator.Send(command);
        return res.Success ? Ok(res) : BadRequest(res);
    }

    [ProducesResponseType(typeof(GenericResponse<List<GetAllAddressQuery>>), StatusCodes.Status200OK)]
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var res = await Mediator.Send(new GetAllContactUsQuery());
        return res.Success ? Ok(res) : BadRequest(res);
    }

    [ProducesResponseType(typeof(GenericResponse<List<GetAllAddressQuery>>), StatusCodes.Status200OK)]
    [HttpGet("id/{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] GetByIdContactUsQuery command)
    {
        var res = await Mediator.Send(command);
        return res.Success ? Ok(res) : BadRequest(res);
    }
}
