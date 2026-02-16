using App.Application.Common.DTO.Address;
using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Address.Command.Create;

public sealed record class CreateAddressCommand(CreateAddressDto dto) : IRequest<GenericResponse<bool>>;
