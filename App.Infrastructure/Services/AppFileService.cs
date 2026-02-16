using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.File;
using App.Application.Common.Responses;
using App.Domain.Entities.List;
using App.Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace App.Infrastructure.Services;

public class AppFileService : IAppFileService
{
    private readonly IGenericRepository<AppFiles> _appFileRepository;
    public AppFileService(IGenericRepository<AppFiles> appFileRepository) => _appFileRepository = appFileRepository;
    
    
    public async Task<GenericResponse<bool>> CreateAsync(List<IFormFile> files, FileTypes type, Guid jobId)
    {
        string fileDirectory;

        switch (type)
        {
            case FileTypes.Job:
                fileDirectory = Path.Combine("wwwroot", "Jobs");
                break;

            case FileTypes.Profile:
                fileDirectory = Path.Combine("wwwroot", "Profiles");
                break;

            default:
                return GenericResponse<bool>.Fail();
        }

        if (!Directory.Exists(fileDirectory))
            Directory.CreateDirectory(fileDirectory);

        foreach (var file in files)
        {
            var fileName = $"{type}_{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            var filePath = Path.Combine(fileDirectory, fileName);
            
            
            using var stream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(stream);

            var data = new AppFiles()
            {
                JobId = jobId,
                FilePath = filePath
            };
            
            await _appFileRepository.InsertAsync(data);
        }

        return GenericResponse<bool>.Ok(true);
    }
}