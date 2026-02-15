using App.Application.Common.Responses;
using MediatR;

namespace App.Application.WorkerService.Command.Delete;

public sealed record DeleteWorkerServiceCommand(int id) : IRequest<GenericResponse<bool>>;
