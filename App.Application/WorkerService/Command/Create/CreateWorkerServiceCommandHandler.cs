using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.WorkerService;
using App.Application.Common.Responses;
using App.Application.WorkerService.Command.Create;
using App.Domain.Entities.Rel;
using MediatR;

namespace App.Application.WorkerService.Command.Create;

public class CreateWorkerServiceCommandHandler : IRequestHandler<CreateWorkerServiceCommand, GenericResponse<bool>>
{
    private readonly IGenericRepository<WorkerServices> _genericRepository;
    public CreateWorkerServiceCommandHandler(IGenericRepository<WorkerServices> genericRepository) => _genericRepository = genericRepository;


    public async Task<GenericResponse<bool>> Handle(CreateWorkerServiceCommand request, CancellationToken cancellationToken)
    {
        var data = new WorkerServices()
        {
            ServiceId = request.ServiceId,
            WorkerId = request.WorkerId
        };

        await _genericRepository.InsertAsync(data);

        return GenericResponse<bool>.Ok(true);
    }
}
