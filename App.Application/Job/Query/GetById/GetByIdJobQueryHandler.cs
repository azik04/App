using App.Application.Common.DTO.Job;
using App.Application.Common.DTO.WorkerJob;
using App.Application.Common.DTO.WorkerJobHistory;
using App.Application.Common.Interfaces;
using App.Application.Common.Responses;
using App.Domain.Entities.History;
using App.Domain.Entities.Main;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace App.Application.Job.Query.GetById;

public class GetByIdJobQueryHandler : IRequestHandler<GetByIdJobQuery, GenericResponse<GetByIdJobDto>>
{
    private readonly IGenericRepository<Jobs> _jobRepository;
    private readonly IGenericRepository<WorkerJobHistories> _workerJobHistoryRepository;
    public GetByIdJobQueryHandler(IGenericRepository<Jobs> jobRepository, IGenericRepository<WorkerJobHistories> workerJobHistoryRepository)
    { 
        _jobRepository = jobRepository; 
        _workerJobHistoryRepository = workerJobHistoryRepository;
    }
 
    public async Task<GenericResponse<GetByIdJobDto>> Handle(GetByIdJobQuery request, CancellationToken cancellationToken)
    {
        var item = await _jobRepository.GetByIdAsync(
            request.id,
            q => q
                .Include(j => j.Address)
                .Include(j => j.Client)
                .Include(j => j.Service)
                .Include(j => j.JobFile)
                .Include(j => j.WorkerJob)
                    .ThenInclude(wj => wj.Workers)
                .Include(j => j.WorkerJobHistory)
                    .ThenInclude(wj => wj.Workers),
            cancellationToken
        );

        var dto = new GetByIdJobDto
        {
            AddressId = item.AddressId,
            AdressName = item.Address.Name,
            Lat = item.Address.Lat,
            Lng = item.Address.Lng,
            Description = item.Description,
            ClientId = item.ClientId,
            ClientName = item.Client.Name + " " + item.Client.Surname,
            ServiceId = item.ServiceId,
            ServiceName = item.Service.Name,
            Status = item.Statuses.ToString(),
            Name = item.Name,
            AppFile = item.JobFile.Select(ph => ph.FilePath).ToList(),
            WorkerJob = item.WorkerJob.Select(wj => new GetByIdWorkerJobDto
            {
                Status = wj.Status.ToString(),
                Id = wj.Id,
                WorkerId = wj.WorkerId,
                WorkerName = wj.Workers.Name + " " + wj.Workers.Surname,
                JobId = wj.JobId,
                FinishAt = wj.FinishAt?.ToString("dd:MM:yyyy HH:mm"),
                CreateAt = wj.CreateAt.ToString("dd:MM:yyyy HH:mm"),
            }).FirstOrDefault(),
            WorkerJobHistory = item.WorkerJobHistory.Select(wj => new GetAllWorkerJobHistoryDto
            {
                Status = wj.Status,
                Id = wj.Id,
                WorkerId = wj.WorkerId,
                WorkerName = wj.Workers.Name + " " + wj.Workers.Surname,
                FinishAt = wj.FinishAt?.ToString("dd:MM:yyyy HH:mm"),
                CreateAt = wj.CreateAt.ToString("dd:MM:yyyy HH:mm"),
            }).OrderByDescending(x => x.CreateAt).ToList(),

        };

        return GenericResponse<GetByIdJobDto>.Ok(dto);
    }
}
