using App.Application.Common.DTO.Address;
using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Address.Command.Create;

public sealed record CreateAddressCommand (string Name, decimal Lat, decimal Lng, string? Address, string AppId) : IRequest<GenericResponse<bool>>;
