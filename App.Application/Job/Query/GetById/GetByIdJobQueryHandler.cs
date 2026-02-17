using App.Application.Common.DTO.Job;
using App.Application.Common.Interfaces.Job;
using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Job.Query.GetById;

public class GetByIdJobQueryHandler : IRequestHandler<GetByIdJobQuery, GenericResponse<GetByIdJobDto>>
{
    private readonly IJobService _jobService;
    public GetByIdJobQueryHandler(IJobService jobService) => _jobService = jobService;


    public async Task<GenericResponse<GetByIdJobDto>> Handle(GetByIdJobQuery request, CancellationToken cancellationToken)
    {
        return await _jobService.GetByIdAsync(request.id);
    }
}
