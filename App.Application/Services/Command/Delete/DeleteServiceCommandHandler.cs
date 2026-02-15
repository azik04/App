using App.Application.Common.Interfaces.Services;
using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Services.Command.Delete;

public class DeleteServiceCommandHandler : IRequestHandler<DeleteServiceCommand, GenericResponse<bool>>
{
    private readonly IServiceService _serviceService;
    public DeleteServiceCommandHandler(IServiceService serviceService) => _serviceService = serviceService;

    public async Task<GenericResponse<bool>> Handle(DeleteServiceCommand request, CancellationToken cancellationToken)
    {
        return await _serviceService.RemoveAsync(request.id);
    }
}
