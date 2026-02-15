using App.Application.Common.Interfaces.Services;
using App.Application.Common.Responses;
using MediatR;

namespace App.Application.WorkerService.Command.Delete;

public class DeleteWorkerServiceCommandHandler : IRequestHandler<DeleteWorkerServiceCommand, GenericResponse<bool>>
{
    private readonly IWorkerServiceService _workerServiceService;
    public DeleteWorkerServiceCommandHandler(IWorkerServiceService workerServiceService) => _workerServiceService = workerServiceService;

    public async Task<GenericResponse<bool>> Handle(DeleteWorkerServiceCommand request, CancellationToken cancellationToken)
    {
        return await _workerServiceService.RemoveAsync(request.id);
    }
}
