using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Address.Command.Delate;

public sealed record DeleteAddressCommand(int id) : IRequest<GenericResponse<bool>>;