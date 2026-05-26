using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.File;
using App.Application.Common.Interfaces.Job;
using App.Application.Common.Responses;
using App.Domain.Entities.Acc;
using App.Domain.Entities.List;
using App.Domain.Entities.Main;
using MediatR;

namespace App.Application.Job.Command.Create;

public class CreateJobCommandHandler : IRequestHandler<CreateJobCommand, GenericResponse<bool>>
{
    private readonly IGenericRepository<Jobs> _jobRepository;
    private readonly IGenericRepository<AppFiles> _appFileRepository;
    private readonly IGenericRepository<Clients> _clientRepository;
    private readonly IGenericRepository<Domain.Entities.List.Statuses> _statusRepository;
    private readonly IGenericRepository<Domain.Entities.List.Services> _serviceRepository;
    private readonly IAppFileService _appFileService;
    public CreateJobCommandHandler(IGenericRepository<Jobs> jobRepository, IAppFileService appFileService,
        IGenericRepository<Domain.Entities.List.Statuses> statusRepository,
        IGenericRepository<Clients> clientRepository,
        IGenericRepository<Domain.Entities.List.Services> serviceRepository)
    {
        _clientRepository = clientRepository;
        _jobRepository = jobRepository;
        _appFileService = appFileService;
        _serviceRepository = serviceRepository;
    }

    public async Task<GenericResponse<bool>> Handle(CreateJobCommand request, CancellationToken cancellationToken)
    {
        var data = new Jobs
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Description = request.Description,
            ClientId = request.ClientId,
            isHandled = false,
            AddressId = request.AddressId,
            ServiceId = request.ServiceId,
            StatusId = 1,
        };

        await _jobRepository.InsertAsync(data);

        var insert = await _appFileService.CreateAsync(request.file, Domain.Enums.FileTypes.Job);

        foreach (var item in insert.Data)
        {
            var photo = new AppFiles
            {
                JobId = data.Id,
                FilePath = item,
                Id = 1
            };

            await _appFileRepository.InsertAsync(photo);
        }

        return GenericResponse<bool>.Ok(true);
    }
}