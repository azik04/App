using App.Application.Common.DTO.Account;
using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Account.Query.GetAll;

public sealed record GetAllAccountQuery (int pageNumber, int pageSize) : IRequest<PaginatedResponse<GetByIdAccount>> { }
