using App.Application.Common.Interfaces.Job;
using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Job.Command.Create;

public class CreateJobCommandHandler : IRequestHandler<CreateJobCommand, GenericResponse<bool>>
{
    private readonly IJobService _jobService;
    public CreateJobCommandHandler(IJobService jobService) => _jobService = jobService;


    public async Task<GenericResponse<bool>> Handle(CreateJobCommand request, CancellationToken cancellationToken)
    {
        return await _jobService.CreateAsync(request.file, request.dto);
    }
}