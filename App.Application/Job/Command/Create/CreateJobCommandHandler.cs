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
    private readonly IAppFileService _appFileService;
    public CreateJobCommandHandler(IGenericRepository<Jobs> jobRepository, IAppFileService appFileService,
        IGenericRepository<AppFiles> appFileRepository)
    {
        _jobRepository = jobRepository;
        _appFileService = appFileService;
        _appFileRepository = appFileRepository;
    }

    public async Task<GenericResponse<bool>> Handle(CreateJobCommand request, CancellationToken cancellationToken)
    {
        var data = new Jobs
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Description = request.Description,
            ClientId = request.ClientId,
            Statuses = Domain.Enums.Statuses.Active,
            AddressId = request.AddressId,
            CreateAt = DateTime.Now,
            ServiceId = request.ServiceId,
        };

        await _jobRepository.InsertAsync(data, cancellationToken);

        var insert = await _appFileService.CreateAsync(request.file, Domain.Enums.FileTypes.Job);

        if (insert?.Data == null || !insert.Data.Any())
            return GenericResponse<bool>.Fail("File upload failed");

        foreach (var item in insert.Data)
        {
            var photo = new AppFiles
            {
                JobId = data.Id,
                FilePath = item
            };

            await _appFileRepository.InsertAsync(photo, cancellationToken);
        }

        return GenericResponse<bool>.Ok(true);
    }
}