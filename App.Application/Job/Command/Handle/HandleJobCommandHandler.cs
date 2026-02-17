using App.Application.Common.Interfaces.Job;
using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Job.Command.Handle;

public class HandleJobCommandHandler : IRequestHandler<HandleJobCommand, GenericResponse<bool>>
{
    private readonly IJobService _jobService;
    public HandleJobCommandHandler(IJobService jobService) => _jobService = jobService;


    public async Task<GenericResponse<bool>> Handle(HandleJobCommand request, CancellationToken cancellationToken)
    {
        return await _jobService.HandleAsync(request.id, request.workerId, request.clientId);
    }
}
