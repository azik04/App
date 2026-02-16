using App.Application.Common.DTO.WorkerService;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.WorkerService;
using App.Application.Common.Responses;
using App.Domain.Entities.Rel;
using App.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;

namespace App.Infrastructure.Services;

public class WorkerServiceService : IWorkerServiceService
{
    private readonly IGenericRepository<WorkerServices> _genericRepository;
    public WorkerServiceService(IGenericRepository<WorkerServices> genericRepository) => _genericRepository = genericRepository;


    public async Task<GenericResponse<bool>> CreateAsync(CreateWorkerServiceDto dto)
    {
        var data = new WorkerServices()
        {
            ServiceId = dto.ServiceId,
            WorkerId = dto.WorkerId
        };

        await _genericRepository.InsertAsync(data);

        return GenericResponse<bool>.Ok(true);
    }

    public async Task<GenericResponse<bool>> RemoveAsync(int id)
    {
        var data = await _genericRepository.GetByIdAsync(id);
        
        _genericRepository.Delete(data);
        
        return GenericResponse<bool>.Ok(true);
    }
}
