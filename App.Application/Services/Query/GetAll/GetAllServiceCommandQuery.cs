using App.Application.Common.DTO.Service;
using App.Application.Common.Interfaces.Services;
using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Services.Query.GetAll;

public class GetAllServiceCommandQuery : IRequestHandler<GetAllServiceQuery, GenericResponse<List<GetAllServiceDto>>>
{
    private readonly IServiceService _serviceService;
    public GetAllServiceCommandQuery(IServiceService serviceService) => _serviceService = serviceService;

    public async Task<GenericResponse<List<GetAllServiceDto>>> Handle(GetAllServiceQuery request, CancellationToken cancellationToken)
    {
        return await _serviceService.GetAllAsync();
    }
}
