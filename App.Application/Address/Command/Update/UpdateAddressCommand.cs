using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Address.Command.Update;

public sealed record UpdateAddressCommand(int id, string Name, decimal Lat, decimal Lng, string? Address) : IRequest<GenericResponse<bool>>;
