using App.Application.Common.DTO.Service;
using App.Application.Common.Interfaces.Services;
using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Services.Command.Create;

public class CreateServiceCommandHandler : IRequestHandler<CreateServiceCommand, GenericResponse<bool>>
{
    private readonly IServiceService _serviceService;
    public CreateServiceCommandHandler(IServiceService serviceService) => _serviceService = serviceService;
    
    public async Task<GenericResponse<bool>> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
    {
        return await _serviceService.CreateAsync(request.dto);
    }
}
