using App.Application.Common.DTO.Job;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Job;
using App.Application.Common.Responses;
using App.Domain.Entities.Acc;
using App.Domain.Entities.List;
using App.Domain.Entities.Main;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Services;

public class JobService : IJobService
{
    private readonly IGenericRepository<Jobs> _jobRepository;
    private readonly IGenericRepository<AppFiles> _appFileRepository;
    public JobService(IGenericRepository<Jobs> jobRepository, IGenericRepository<AppFiles> appFileRepository)
    {
        _appFileRepository = appFileRepository;
        _jobRepository = jobRepository;
    }


    public async Task<GenericResponse<bool>> CreateAsync(List<IFormFile> file, CreateJobDto dto)
    {
        var data = new Jobs
        {
            Description = dto.Description,
            AddressId = dto.AddressId,
            ClientId = dto.ClientId,
            isHandled = false,
            Name = dto.Name,
            ServiceId = dto.ServiceId,
            StatusId = 1,
            isActive = false
        };

        await _jobRepository.InsertAsync(data);

        var directory = Path.Combine("wwwroot", "job");
        if (!Directory.Exists(directory))
            Directory.CreateDirectory(directory);
            
       foreach(var item in file)
       {
            var fileName = "Job" + data.Id + Path.GetExtension(item.Name);
            var filePath = Path.Combine(directory, fileName);

            using (var steam = new FileStream(filePath, FileMode.Create))
                await item.CopyToAsync(steam);

            var photo = new AppFiles
            {
                FilePath = filePath,
                JobId = data.Id,
            };

            await _appFileRepository.InsertAsync(photo);
       }

        return GenericResponse<bool>.Ok(true);
    }

    public async Task<GenericResponse<List<GetAllJobDto>>> GetAllByClientAsync(Guid clientId)
    {
        var data = await _jobRepository.Where(x => x.ClientId == clientId)
            .Include(x => x.Worker)
            .Include(x => x.Client)
            .Include(x => x.Address)
            .Include(x => x.Statuse)
            .Include(x => x.Service)
            .Include(x => x.JobFile)
            .Select(item => new GetAllJobDto
            {
                AddressId = item.AddressId,
                AdressName = item.Address.Name,
                X = item.Address.X,
                Y = item.Address.Y,
                Description = item.Description,
                ClientId = item.ClientId,
                ClientName = item.Client.Name + " " + item.Client.Surname,
                WorkerId = item.WorkerId,
                WorkerName = item.Worker.Name + " " + item.Worker.Surname,
                WorkerRating = item.Worker.Rating,
                ServiceId = item.ServiceId,
                ServiceName = item.Service.Name,
                isActive = item.isActive,
                isHandled = item.isHandled,
                Name = item.Name,
                StatusId = item.StatusId,
                StatusName = item.Statuse.Name,
                AppFile = item.JobFile.Select(ph => ph.FilePath).ToList()
            }).ToListAsync();

        return GenericResponse<List<GetAllJobDto>>.Ok(data);
    }

    public async Task<GenericResponse<List<GetAllJobDto>>> GetAllByWorkerAsync(int serviceId)
    {
        var data = await _jobRepository.Where(x => x.ServiceId == serviceId)
                    .Include(x => x.Worker)
                    .Include(x => x.Client)
                    .Include(x => x.Address)
                    .Include(x => x.Statuse)
                    .Include(x => x.Service)
                    .Include(x => x.JobFile)
                    .Select(item => new GetAllJobDto
                    {
                        AddressId = item.AddressId,
                        AdressName = item.Address.Name,
                        X = item.Address.X,
                        Y = item.Address.Y,
                        Description = item.Description,
                        ClientId = item.ClientId,
                        ClientName = item.Client.Name + " " + item.Client.Surname,
                        WorkerId = item.WorkerId,
                        WorkerName = item.Worker.Name + " " + item.Worker.Surname,
                        WorkerRating = item.Worker.Rating,
                        ServiceId = item.ServiceId,
                        ServiceName = item.Service.Name,
                        isActive = item.isActive,
                        isHandled = item.isHandled,
                        Name = item.Name,
                        StatusId = item.StatusId,
                        StatusName = item.Statuse.Name,
                        AppFile = item.JobFile.Select(ph => ph.FilePath).ToList()
                    }).ToListAsync();

        return GenericResponse<List<GetAllJobDto>>.Ok(data);
    }

    public async Task<GenericResponse<GetByIdJobDto>> GetByIdAsync(Guid id)
    {
        var item = await _jobRepository.GetByIdAsync(id);

        var dto = new GetByIdJobDto
        {
            AddressId = item.AddressId,
            AdressName = item.Address.Name,
            X = item.Address.X,
            Y = item.Address.Y,
            Description = item.Description,
            ClientId = item.ClientId,
            ClientName = item.Client.Name + " " + item.Client.Surname,
            WorkerId = item.WorkerId,
            WorkerName = item.Worker.Name + " " + item.Worker.Surname,
            WorkerRating = item.Worker.Rating,
            ServiceId = item.ServiceId,
            ServiceName = item.Service.Name,
            isActive = item.isActive,
            isHandled = item.isHandled,
            Name = item.Name,
            StatusId = item.StatusId,
            StatusName = item.Statuse.Name,
            AppFile = item.JobFile.Select(ph => ph.FilePath).ToList()
        };

        return GenericResponse<GetByIdJobDto>.Ok(dto);
    }

    public async Task<GenericResponse<bool>> HandleAsync(Guid id, Guid workerId)
    {
        var item = await _jobRepository.GetByIdAsync(id);
        if (item == null)
            return GenericResponse<bool>.Fail();

        item.StatusId = 2;
        item.WorkerId = workerId;
        item.isHandled = true;

        _jobRepository.Update(item);

        return GenericResponse<bool>.Ok(true);
    }

    public async Task<GenericResponse<bool>> RemoveAsync(Guid id, Guid clientId)
    {
        var item = await _jobRepository.GetByIdAsync(id);
        if (item == null)
            return GenericResponse<bool>.Fail();

        _jobRepository.Delete(item);

        return GenericResponse<bool>.Ok(true);
    }

    public async Task<GenericResponse<bool>> UnhandleAsync(Guid id, Guid clientId)
    {
        var item = await _jobRepository.GetByIdAsync(id);
        if (item.ClientId != clientId || item == null)
            return GenericResponse<bool>.Fail();

        item.StatusId = 1;
        item.WorkerId = null;
        item.isHandled = false;

        _jobRepository.Update(item);

        return GenericResponse<bool>.Ok(true);
    }
}
