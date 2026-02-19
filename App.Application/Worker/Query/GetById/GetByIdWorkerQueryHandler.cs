using App.Application.Common.DTO.Worker;
using App.Application.Common.Interfaces;
using App.Application.Common.Responses;
using App.Domain.Entities.Acc;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace App.Application.Worker.Query.GetById;

public class GetByIdWorkerQueryHandler : IRequestHandler<GetByIdWorkerQuery, GenericResponse<GetByIdWorkerDto>>
{
    private readonly IGenericRepository<Workers> _workersRepository;

    public GetByIdWorkerQueryHandler(IGenericRepository<Workers> workersRepository) => _workersRepository = workersRepository;


    public async Task<GenericResponse<GetByIdWorkerDto>> Handle(GetByIdWorkerQuery request, CancellationToken cancellationToken)
    {
        var data = await _workersRepository.Where(x => x.Id == request.id)
            .Include(x => x.Review)
            .Include(x => x.WorkerService)
            .Include(x => x.Payment)
            .SingleOrDefaultAsync();

        var dto = new GetByIdWorkerDto()
        {
            Name = data.Name,
            Id = data.Id,
            FilePath = data.FilePath,
            Surname = data.Surname,
            Service = data.WorkerService.Select(x => x.Service.Name).ToList(),
            Rating = data.Rating,
            ReviewCount = data.Review.Count,
            HistoryCount = data.Job.Where(x => x.StatusId == 3).Count()
        };
        
        return GenericResponse<GetByIdWorkerDto>.Ok(dto);
    }
}