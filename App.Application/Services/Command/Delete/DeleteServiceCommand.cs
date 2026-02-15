using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Services.Command.Delete;

public sealed record DeleteServiceCommand(int id) : IRequest<GenericResponse<bool>>;