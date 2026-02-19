using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.File;
using App.Application.Common.Interfaces.Job;
using App.Application.Common.Responses;
using App.Domain.Entities.Main;
using MediatR;

namespace App.Application.Job.Command.Create;

public class CreateJobCommandHandler : IRequestHandler<CreateJobCommand, GenericResponse<bool>>
{
    private readonly IGenericRepository<Jobs> _jobRepository;
    private readonly IAppFileService _appFileService;
    public CreateJobCommandHandler(IGenericRepository<Jobs> jobRepository, IAppFileService appFileService)
    {
        _jobRepository = jobRepository;
        _appFileService = appFileService;
    }

    public async Task<GenericResponse<bool>> Handle(CreateJobCommand request, CancellationToken cancellationToken)
    {
        var data = new Jobs
        {
            Description = request.Description,
            AddressId = request.AddressId,
            ClientId = request.ClientId,
            isHandled = false,
            Name = request.Name,
            ServiceId = request.ServiceId,
            StatusId = 1,
            isActive = false
        };

        await _jobRepository.InsertAsync(data);

        return GenericResponse<bool>.Ok(true);

    }
}