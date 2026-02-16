using App.Application.Common.Interfaces.WorkerService;
using App.Application.Common.Responses;
using App.Application.WorkerService.Command.Create;
using MediatR;

namespace App.Application.WorkerService.Command.Create;

public class CreateWorkerServiceCommandHandler : IRequestHandler<CreateWorkerServiceCommand, GenericResponse<bool>>
{
    private readonly IWorkerServiceService _workerServiceService;
    public CreateWorkerServiceCommandHandler(IWorkerServiceService workerServiceService) => _workerServiceService = workerServiceService;

    public async Task<GenericResponse<bool>> Handle(CreateWorkerServiceCommand request, CancellationToken cancellationToken)
    {
        return await _workerServiceService.CreateAsync(request.dto);
    }
}
