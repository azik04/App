using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Job.Command.Submit;

public sealed record SubmitJobCommand(Guid id, Guid workerId) : IRequest<GenericResponse<bool>>;
