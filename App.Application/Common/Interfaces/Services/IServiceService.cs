using App.Application.Common.DTO.Service;
using App.Application.Common.Responses;

namespace App.Application.Common.Interfaces.Services;

public interface IServiceService
{
    Task<GenericResponse<bool>> CreateAsync(CreateServiceDto dto);
    Task<GenericResponse<List<GetAllServiceDto>>> GetAllAsync();
    Task<GenericResponse<bool>> RemoveAsync(int Id);
}
