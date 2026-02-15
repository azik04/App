using App.Application.Common.DTO.Service;
using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Services.Command.Create;

public sealed record class CreateServiceCommand(CreateServiceDto dto) : IRequest<GenericResponse<bool>>;