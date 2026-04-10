using App.Application.Common.DTO.Refresh;
using App.Application.Common.Responses;

namespace App.Application.Common.Interfaces.Refresh;

public interface IRefreshService
{
    Task<GenericResponse<List<GetAllRefreshDto>>> GetAllAsync();
}
