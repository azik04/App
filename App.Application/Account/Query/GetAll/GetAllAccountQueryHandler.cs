using App.Application.Common.DTO.Account;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Account;
using App.Application.Common.Responses;
using App.Domain.Entities.Acc;
using MediatR;

namespace App.Application.Account.Query.GetAll;

public class GetAllAccountQueryHandler : IRequestHandler<GetAllAccountQuery, PaginatedResponse<GetByIdAccount>>
{
    private readonly IAccountService _accountService;

    public GetAllAccountQueryHandler(IAccountService accountService)
    {
        _accountService = accountService;
    }
    public async Task<PaginatedResponse<GetByIdAccount>> Handle(GetAllAccountQuery request, CancellationToken cancellationToken)
    {
        return await _accountService.GetAllAsync(request.pageNumber, request.pageSize);
    }
}
