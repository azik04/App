using App.Application.Common.DTO.Account;
using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Account.Query.GetById;

public sealed record GetByIdQuery(string id) : IRequest<GenericResponse<GetByIdAccount>>;
