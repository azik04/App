using App.Application.Common.DTO.Job;
using App.Application.Common.Responses;
using Microsoft.AspNetCore.Http;

namespace App.Application.Common.Interfaces.Job;

public interface IJobService
{
    Task<GenericResponse<bool>> CreateAsync(List<IFormFile> file, CreateJobDto dto);
    Task<GenericResponse<List<GetAllJobDto>>> GetAllByWorkerAsync(int serviceId);
    Task<GenericResponse<List<GetAllJobDto>>> GetAllByClientAsync(Guid clientId);
    Task<GenericResponse<GetByIdJobDto>> GetByIdAsync(Guid id);
    Task<GenericResponse<bool>> HandleAsync(Guid id, Guid workerId);
    Task<GenericResponse<bool>> UnhandleAsync(Guid id, Guid clientId);
    Task<GenericResponse<bool>> RemoveAsync(Guid id, Guid clientId);
}
