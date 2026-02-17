using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Job.Command.Handle;

public sealed record HandleJobCommand(Guid id, Guid workerId, Guid? clientId) : IRequest<GenericResponse<bool>>;
