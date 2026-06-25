using App.Application.Address.Query.GetAll;
using App.Application.Common.DTO.ContactUs;
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
    /// <summary>
    /// Retrieves all contact us messages.
    /// </summary>
    /// <returns>Returns a list of contact us messages.</returns>
    [ProducesResponseType(typeof(GenericResponse<List<GetAllContactUsDto>>), StatusCodes.Status200OK)]
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var res = await Mediator.Send(new GetAllContactUsQuery());
        return res.Success ? Ok(res) : BadRequest(res);
    }


    /// <summary>
    /// Retrieves a contact us message by its identifier.
    /// </summary>
    /// <param name="command">Contains the contact us identifier.</param>
    /// <returns>Returns the contact us details.</returns>
    [ProducesResponseType(typeof(GenericResponse<GetByIdContactUsDto>), StatusCodes.Status200OK)]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] GetByIdContactUsQuery command)
    {
        var res = await Mediator.Send(command);
        return res.Success ? Ok(res) : BadRequest(res);
    }


    /// <summary>
    /// Creates a new contact us message.
    /// </summary>
    /// <param name="command">Contains the contact us information to create.</param>
    /// <returns>Returns success status after creating the contact request.</returns>
    [ProducesResponseType(typeof(GenericResponse<bool>), StatusCodes.Status200OK)]
    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateContactUsCommand command)
    {
        var res = await Mediator.Send(command);
        return res.Success ? Ok(res) : BadRequest(res);
    }
}
