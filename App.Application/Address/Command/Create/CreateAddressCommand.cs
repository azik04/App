using App.Application.Common.DTO.Address;
using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Address.Command.Create;

public sealed record CreateAddressCommand (string Name, string X, string Y, string? Address, Guid ClientId) 
    : IRequest<GenericResponse<bool>>;
