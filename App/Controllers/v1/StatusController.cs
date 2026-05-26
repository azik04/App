using App.Application.Services.Query.GetAll;
using App.Application.Statuses.Command;
using App.Application.Statuses.Query;
using App.Application.WorkerService.Command.Create;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ApiControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateStatusCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Success ? Ok(result) : BadRequest(result);
        }


        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await Mediator.Send(new GetAllStatusQuery());
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
