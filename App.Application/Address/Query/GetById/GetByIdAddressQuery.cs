using App.Application.Common.DTO.Address;
using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Address.Query.GetById;

public sealed record GetByIdAddressQuery(int id) : IRequest<GenericResponse<GetByIdAddressDto>>;