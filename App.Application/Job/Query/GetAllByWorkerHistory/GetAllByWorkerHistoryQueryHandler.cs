using App.Application.Common.DTO.Job;
using App.Application.Common.Interfaces.Job;
using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Job.Query.GetAllByWorkerHistory;

public class GetAllByWorkerHistoryQueryHandler : IRequestHandler<GetAllByWorkerHistoryQuery, GenericResponse<List<GetAllJobDto>>>
{
    private readonly IJobService _jobService;
    public GetAllByWorkerHistoryQueryHandler(IJobService jobService) => _jobService = jobService;


    public async Task<GenericResponse<List<GetAllJobDto>>> Handle(GetAllByWorkerHistoryQuery request, CancellationToken cancellationToken)
    {
        return await _jobService.GetAllByWorkerHistoryAsync(request.workerId);
    }
}
