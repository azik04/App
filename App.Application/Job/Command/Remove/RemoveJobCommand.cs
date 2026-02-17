using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Job.Command.Remove;

public sealed record RemoveJobCommand(Guid id, Guid clientId) : IRequest<GenericResponse<bool>>;
