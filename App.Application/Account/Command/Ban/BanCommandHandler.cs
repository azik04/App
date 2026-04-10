using System;
using System.Collections.Generic;
using System.Text;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Account;
using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Account.Command.Ban;

public class BanCommandHandler : IRequestHandler<BanCommand, GenericResponse<bool>>
{
    private readonly IAccountService _accountService;
    public BanCommandHandler(IAccountService accountService)
    {
        _accountService = accountService;
    }


    public async Task<GenericResponse<bool>> Handle(BanCommand request, CancellationToken cancellationToken)
    {
        return await _accountService.BanAsync(request.id);
    }
}
