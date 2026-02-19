using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Job.Command.Remove;

public sealed record RemoveJobCommand(Guid id) : IRequest<GenericResponse<bool>>;
