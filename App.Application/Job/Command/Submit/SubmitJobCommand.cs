using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Job.Command.Submit;

public sealed record SubmitJobCommand(Guid id) : IRequest<GenericResponse<bool>>;
