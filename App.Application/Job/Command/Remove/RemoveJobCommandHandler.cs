using App.Application.Common.Interfaces.Job;
using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Job.Command.Remove;

public class RemoveJobCommandHandler : IRequestHandler<RemoveJobCommand, GenericResponse<bool>>
{
    private readonly IJobService _jobService;
    public RemoveJobCommandHandler(IJobService jobService) => _jobService = jobService;

    public async Task<GenericResponse<bool>> Handle(RemoveJobCommand request, CancellationToken cancellationToken)
    {
        return await _jobService.RemoveAsync(request.id, request.clientId);
    }
}
