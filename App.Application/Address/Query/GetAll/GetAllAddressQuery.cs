using App.Application.Common.DTO.Address;
using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Address.Query.GetAll;

public record GetAllAddressQuery(Guid clientId) : IRequest<GenericResponse<List<GetAllAddressDto>>>;