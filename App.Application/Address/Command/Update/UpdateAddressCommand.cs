using App.Application.Common.DTO.Address;
using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Address.Command.Update;

public sealed record UpdateAddressCommand(int id, UpdateAddressDto dto) : IRequest<GenericResponse<bool>>;