using App.Application.Common.Interfaces.File;
using App.Application.Common.Responses;
using App.Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace App.Infrastructure.Services;

public class AppFileService : IAppFileService
{
    public Task<GenericResponse<bool>> CreateAsync(List<IFormFile> file, FileTypes type)
    {
        throw new NotImplementedException();
    }
}
