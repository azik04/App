using App.Application.Common.Responses;
using App.Domain.Enums;
using MediatR;

namespace App.Application.WorkerJob.Command.Create;

public sealed record CreateWorkerJobCommand(Guid WorkerId, Guid JobId, WorkerJobStatus? workerJobStatus) : IRequest<GenericResponse<bool>>;
