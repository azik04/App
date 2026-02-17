using App.Application.Common.Interfaces.Job;
using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Job.Command.Submit;

public class SubmitJobCommandHandler : IRequestHandler<SubmitJobCommand, GenericResponse<bool>>
{
    private readonly IJobService _jobService;
    public SubmitJobCommandHandler(IJobService jobService) => _jobService = jobService;


    public async Task<GenericResponse<bool>> Handle(SubmitJobCommand request, CancellationToken cancellationToken)
    {
        return await _jobService.SubmitAsync(request.id, request.workerId);
    }
}
