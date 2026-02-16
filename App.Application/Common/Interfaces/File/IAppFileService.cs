using App.Application.Common.Responses;
using App.Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace App.Application.Common.Interfaces.File;

public interface IAppFileService
{
    Task<GenericResponse<bool>> CreateAsync(List<IFormFile> file, FileTypes type);
}
