using App.Application.Common.DTO.Job;
using App.Application.Common.Interfaces.Job;
using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Job.Query.GetAllByClient;

public class GetAllByClientQueryHandler : IRequestHandler<GetAllByClientQuery, GenericResponse<List<GetAllJobDto>>>
{
    private readonly IJobService _jobService;
    public GetAllByClientQueryHandler(IJobService jobService) => _jobService = jobService;


    public async Task<GenericResponse<List<GetAllJobDto>>> Handle(GetAllByClientQuery request, CancellationToken cancellationToken)
    {
        return await _jobService.GetAllByClientAsync(request.clientId);
    }
}
