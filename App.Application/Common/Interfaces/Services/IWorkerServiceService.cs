using App.Application.Common.DTO.WorkerService;
using App.Application.Common.Responses;

namespace App.Application.Common.Interfaces.Services;

public interface IWorkerServiceService
{
    Task<GenericResponse<bool>> CreateAsync(CreateWorkerServiceDto dto);
    Task<GenericResponse<bool>> RemoveAsync(int id);
}
