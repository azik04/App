using App.Application.Common.DTO.WorkerService;
using App.Application.Common.Responses;
using MediatR;

namespace App.Application.WorkerService.Command.Create;

public sealed record CreateWorkerServiceCommand( int ServiceId, Guid WorkerId ) : IRequest<GenericResponse<bool>>;