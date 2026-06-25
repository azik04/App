using App.Application.Common.DTO.Job;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Account;
using App.Application.Common.Responses;
using App.Domain.Entities.Main;
using App.Domain.Entities.Rel;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace App.Application.Job.Query.GetAllHandled;

public class GetAllHandledJobQueryHandler : IRequestHandler<GetAllHandledJobQuery, GenericResponse<List<GetAllJobDto>>>
{
    private readonly IGenericRepository<Jobs> _jobRepository;
    private readonly IGenericRepository<WorkerJobs> _workerJobRepository;
    private readonly IAccountService _accountService;
    public GetAllHandledJobQueryHandler(IGenericRepository<Jobs> jobRepository, 
        IGenericRepository<WorkerJobs> workerJobRepository, IAccountService accountService)
    {
        _jobRepository = jobRepository;
        _workerJobRepository = workerJobRepository;
        _accountService = accountService;
    }


    public async Task<GenericResponse<List<GetAllJobDto>>> Handle(GetAllHandledJobQuery request, CancellationToken cancellationToken)
    {
        var user = await _accountService.GetById(request.appId);
        if (user.Data == null)
            return GenericResponse<List<GetAllJobDto>>.Fail();

        List<GetAllJobDto> dtos = new();

        if (user.Data.ClientId != null && user.Data.WorkerId == null)
        {
            dtos = await _jobRepository
                .Where(x => x.ClientId == user.Data.ClientId && x.ServiceId == request.serviceId &&
                            (x.Statuses == Domain.Enums.Statuses.IsHandled || x.Statuses == Domain.Enums.Statuses.Done))
                .OrderByDescending(x => x.CreateAt)
                .Select(item => new GetAllJobDto
                {
                    AddressId = item.AddressId,
                    AdressName = item.Address.Name,
                    ServiceId = item.ServiceId,
                    ServiceName = item.Service.Name,
                    Id = item.Id,
                    Name = item.Name,
                    AppFile = item.JobFile
                        .Select(ph => ph.FilePath)
                        .FirstOrDefault()
                })
                .ToListAsync(cancellationToken);
        }
        else if (user.Data.WorkerId != null && user.Data.ClientId == null)
        {
            dtos = await _workerJobRepository
                .Where(x => x.WorkerId == user.Data.WorkerId && x.Jobs.ServiceId == request.serviceId &&
                            (x.Jobs.Statuses == Domain.Enums.Statuses.IsHandled || x.Jobs.Statuses == Domain.Enums.Statuses.Done))
                .Select(item => new GetAllJobDto
                {
                    AddressId = item.Jobs.AddressId,
                    AdressName = item.Jobs.Address.Name,
                    ServiceId = item.Jobs.ServiceId,
                    ServiceName = item.Jobs.Service.Name,
                    Id = item.Jobs.Id,
                    Name = item.Jobs.Name,
                    AppFile = item.Jobs.JobFile
                        .Select(ph => ph.FilePath)
                        .FirstOrDefault()
                })
                .ToListAsync(cancellationToken);
        }

        return GenericResponse<List<GetAllJobDto>>.Ok(dtos);
    }
}
