using App.Application.Common.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace App.Application.Job.Command.Create;

public sealed record CreateJobCommand(List<IFormFile> file, string Name, string? Description, Guid ClientId, Guid? WorkerId, 
    int AddressId, int ServiceId, bool isActive) : IRequest<GenericResponse<bool>>;