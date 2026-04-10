using App.Application.Common.Responses;
using App.Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace App.Application.Common.Interfaces.File;

public interface IAppFileService
{
    Task<GenericResponse<List<string>>> CreateAsync(List<IFormFile> files, FileTypes type);
    GenericResponse<bool> Delete(string urlPath);
}
