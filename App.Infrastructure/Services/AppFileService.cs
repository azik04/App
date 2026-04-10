using App.Application.Common.Interfaces.File;
using App.Application.Common.Responses;
using App.Domain.Enums;
using Microsoft.AspNetCore.Http;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace App.Infrastructure.Services;

public class AppFileService : IAppFileService
{   
    public async Task<GenericResponse<List<string>>> CreateAsync(List<IFormFile> files, FileTypes type)
    {
        var filePaths = new List<string>();
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
                return GenericResponse<List<string>>.Fail();
        }

        if (!Directory.Exists(fileDirectory))
            Directory.CreateDirectory(fileDirectory);

        foreach (var file in files)
        {
            var fileName = $"{type}_{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";

            var physicalPath = Path.Combine(fileDirectory, fileName);

            using var image = await Image.LoadAsync(file.OpenReadStream());
            image.Mutate(x => x.Resize(new ResizeOptions
            {
                Mode = ResizeMode.Crop,
                Position = AnchorPositionMode.Center,
                Size = new Size(400, 400)
            }));

            var urlPath = $"/{type}s/{fileName}"; 
            filePaths.Add(urlPath);
            
            await image.SaveAsync(physicalPath);     
        }

        return GenericResponse<List<string>>.Ok(filePaths);
    }

    public GenericResponse<bool> Delete(string urlPath)
    {
        var relativePath = urlPath.TrimStart('/');
        var physicalPath = Path.Combine("wwwroot", relativePath);

        if (!File.Exists(physicalPath))
            return GenericResponse<bool>.Fail("File not found");

        File.Delete(physicalPath);
        return GenericResponse<bool>.Ok(true);
    }
}