using App.Application.Common.DTO.Job;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Job;
using App.Application.Common.Responses;
using App.Domain.Entities.Acc;
using App.Domain.Entities.Main;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace App.Application.Job.Query.GetAllByWorkerHistory;

public class GetAllByWorkerHistoryQueryHandler : IRequestHandler<GetAllByWorkerHistoryQuery, GenericResponse<List<GetAllJobDto>>>
{
    private readonly IGenericRepository<Jobs> _jobRepository;
    public GetAllByWorkerHistoryQueryHandler(IGenericRepository<Jobs> jobRepository) => _jobRepository = jobRepository;


    public async Task<GenericResponse<List<GetAllJobDto>>> Handle(GetAllByWorkerHistoryQuery request, CancellationToken cancellationToken)
    {
        var data = await _jobRepository.Where(x => x.WorkerId == request.workerId && x.StatusId == 3)
            .Include(x => x.Worker)
            .Include(x => x.Client)
            .Include(x => x.Address)
            .Include(x => x.Statuse)
            .Include(x => x.Service)
            .Include(x => x.JobFile)
            .Select(item => new GetAllJobDto
            {
                AddressId = item.AddressId,
                AdressName = item.Address.Name,
                X = item.Address.X,
                Y = item.Address.Y,
                Description = item.Description,
                ClientId = item.ClientId,
                ClientName = item.Client.Name + " " + item.Client.Surname,
                WorkerId = item.WorkerId,
                WorkerName = item.Worker.Name + " " + item.Worker.Surname,
                WorkerRating = item.Worker.Rating,
                ServiceId = item.ServiceId,
                ServiceName = item.Service.Name,
                isActive = item.isActive,
                isHandled = item.isHandled,
                Name = item.Name,
                StatusId = item.StatusId,
                StatusName = item.Statuse.Name,
                AppFile = item.JobFile.Select(ph => ph.FilePath).ToList()
            }).ToListAsync();

        return GenericResponse<List<GetAllJobDto>>.Ok(data);
    }
}
