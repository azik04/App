using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Job.Command.Remove;

public sealed record RemoveJobCommand(Guid id, string appId) : IRequest<GenericResponse<bool>>;
