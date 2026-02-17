using App.Application.Common.DTO.Job;
using App.Application.Common.Interfaces.Job;
using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Job.Query.GetById;

public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, GenericResponse<GetByIdJobDto>>
{
    private readonly IJobService _jobService;
    public GetByIdQueryHandler(IJobService jobService) => _jobService = jobService;


    public Task<GenericResponse<GetByIdJobDto>> Handle(GetByIdQuery request, CancellationToken cancellationToken)
    {
        return _jobService.GetByIdAsync(request.id);
    }
}
