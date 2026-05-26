using App.Application.Common.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace App.Application.Job.Command.Create;

public sealed record CreateJobCommand(List<IFormFile> file, string Name, string? Description, Guid ClientId, 
    int AddressId, int ServiceId) : IRequest<GenericResponse<bool>>;