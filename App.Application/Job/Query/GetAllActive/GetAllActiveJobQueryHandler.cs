using App.Application.Common.DTO.Job;
using App.Application.Common.Interfaces;
using App.Application.Common.Responses;
using App.Domain.Entities.Main;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace App.Application.Job.Query.GetAllByWorker;

public class GetAllActiveJobQueryHandler : IRequestHandler<GetAllActiveJobQuery, GenericResponse<List<GetAllJobDto>>>
{
    private readonly IGenericRepository<Jobs> _jobRepository;
    public GetAllActiveJobQueryHandler(IGenericRepository<Jobs> jobRepository) => _jobRepository = jobRepository;


    public async Task<GenericResponse<List<GetAllJobDto>>> Handle(GetAllActiveJobQuery request, CancellationToken cancellationToken)
    {
        var data = await _jobRepository
            .Where(x => x.ServiceId == request.serviceId && x.Statuses == Domain.Enums.Statuses.Active)
            .Include(x => x.Client)
            .Include(x => x.Address)
            .Include(x => x.Service)
            .Include(x => x.JobFile)
            .Select(item => new GetAllJobDto
            {
                Id = item.Id,
                AddressId = item.AddressId,
                AdressName = item.Address.Name,
                ServiceId = item.ServiceId,
                ServiceName = item.Service.Name,
                Name = item.Name,
                AppFile = item.JobFile.Select(ph => ph.FilePath).FirstOrDefault()
            }).ToListAsync(cancellationToken);

        return GenericResponse<List<GetAllJobDto>>.Ok(data);
    }
}
