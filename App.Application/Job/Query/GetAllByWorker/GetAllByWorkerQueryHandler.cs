using App.Application.Common.DTO.Job;
using App.Application.Common.Interfaces.Job;
using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Job.Query.GetAllByWorker;

public class GetAllByWorkerQueryHandler : IRequestHandler<GetAllByWorkerQuery, GenericResponse<List<GetAllJobDto>>>
{
    private readonly IJobService _jobService;
    public GetAllByWorkerQueryHandler(IJobService jobService) => _jobService = jobService;


    public async Task<GenericResponse<List<GetAllJobDto>>> Handle(GetAllByWorkerQuery request, CancellationToken cancellationToken)
    {
        return await _jobService.GetAllByWorkerAsync(request.serviceId);
    }
}
