using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.WorkerService;
using App.Application.Common.Responses;
using App.Domain.Entities.Rel;
using MediatR;

namespace App.Application.WorkerService.Command.Delete;

public class DeleteWorkerServiceCommandHandler : IRequestHandler<DeleteWorkerServiceCommand, GenericResponse<bool>>
{
    private readonly IGenericRepository<WorkerServices> _genericRepository;
    public DeleteWorkerServiceCommandHandler(IGenericRepository<WorkerServices> genericRepository) => _genericRepository = genericRepository;


    public async Task<GenericResponse<bool>> Handle(DeleteWorkerServiceCommand request, CancellationToken cancellationToken)
    {
        var data = await _genericRepository.GetByIdAsync(request.id);

        _genericRepository.Delete(data);

        return GenericResponse<bool>.Ok(true);
    }
}
