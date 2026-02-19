using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Address.Command.Update;

public sealed record UpdateAddressCommand (int Id, string Name, string X, string Y, string? Address) 
    : IRequest<GenericResponse<bool>>;