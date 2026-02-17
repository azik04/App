using App.Application.Common.DTO.Job;
using App.Application.Common.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace App.Application.Job.Command.Create;

public sealed record CreateJobCommand(List<IFormFile> file, CreateJobDto dto) : IRequest<GenericResponse<bool>>;